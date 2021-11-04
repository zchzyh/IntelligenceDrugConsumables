using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Application.Busines.PerfStrategy;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Entity.PerfStrategy;
using LeaRun.Application.Entity.PerfStrategy.ViewModel;
using LeaRun.Util;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeaRun.Application.Web.Areas.PerfStrategy.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class CriticalSuccessFactorController : MvcControllerBase
    {
        private readonly BpeVa004BLL _bpeVa004Bll = new BpeVa004BLL();
        private readonly DictionaryBLL _dictionaryBll = new DictionaryBLL();
        private readonly BpeVa001BLL _bpeVa001Bll = new BpeVa001BLL();
        private readonly BpeVa003BLL _bpeVa003Bll = new BpeVa003BLL();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditFactor(string keyValue)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DeleteRecord(string keyValue)
        {
            _bpeVa004Bll.DeleteRecord(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 获取维度
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDimensionList()
        {
           var dimensions= _dictionaryBll.GetDimensionalities(GetDefaultPagination("BSCBH"),"");
           return Content(dimensions.ToJson());

        }

        /// <summary>
        /// 获取成功因素列表
        /// </summary>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        public ActionResult GetSuccessFactorList(string jxbm)
        {
            var factors = _bpeVa004Bll.GetPageList(GetDefaultPagination("CSFBH"), JsonConvert.SerializeObject(new { jxbm }));
            return Content(factors.ToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        public ActionResult GetTreeList(string jxbm)
        {
            var dimensions = _bpeVa001Bll.GetPageList(GetDefaultPagination("CREATEAT"), JsonConvert.SerializeObject(new { jxbm })).ToList();
            var themes = _bpeVa003Bll.GetPageList(GetDefaultPagination("CREATEAT"), JsonConvert.SerializeObject(new { jxbm })).ToList();
            var factors =_bpeVa004Bll.GetPageList(GetDefaultPagination("CREATEAT"), JsonConvert.SerializeObject(new { jxbm })).ToList();
            var treeEntites = FilTreeTable(dimensions, themes, factors);
            return Content(treeEntites.TreeToJson());
        }

        private List<TreeEntity> FilTreeTable(List<BpeVa001Model> dimensions, List<BpeVa003Model> themes, List<BpeVa004Model> factors)
        {
            var treeList = new List<TreeEntity>();

            //过滤列表
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    tableList = tableList.Where(t => t.CJBMC.Contains(keyword) || t.CJBQM.Contains(keyword)).ToList();
            //}
            foreach (var item in dimensions)
            {
                var themeList = themes.Where(t => t.SMBH == item.SMBH).ToList();
                TreeEntity tree = new TreeEntity();
                bool hasChildren = themeList.Count <1 ? false : true;
                tree.id = "C_" + item.SMBH;
                tree.text = item.ZLZMB.Trim();
                tree.value = "0";
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.hasChildren = hasChildren;
                tree.parentId = "0";
                tree.img = "fa fa-sitemap";
                treeList.Add(tree);


                foreach (var theme in themeList)
                {
                    var factorList = factors.Where(t => t.ZTBH == theme.ZTBH).ToList();
                    TreeEntity subTree = new TreeEntity();
                     hasChildren = factorList.Count < 1 ? false : true;
                    subTree.id = "T_" + theme.ZTBH;
                    subTree.text = theme.ZTMC.Trim();
                    subTree.value = theme.ZTBH;
                    subTree.isexpand = true;
                    subTree.complete = true;
                    subTree.showcheck = true;
                    subTree.hasChildren = hasChildren;
                    subTree.parentId = tree.id;
                    subTree.title = theme.ZTMC.Trim();
                    //tree.img = "fa fa-sitemap";
                    treeList.Add(subTree);


                    foreach (var factor in factorList)
                    {
                        TreeEntity subTree3 = new TreeEntity();
                        subTree3.id = "F_"+factor.CSFBH;
                        subTree3.text = factor.CSFMC.Trim();
                        subTree3.value = factor.CSFBH;
                        subTree3.isexpand = true;
                        subTree3.complete = true;
                        subTree3.showcheck = true;
                        subTree3.hasChildren = false;
                        subTree3.parentId = subTree.id;
                        subTree3.title = factor.CSFMC.Trim();
                        //tree.img = "fa fa-sitemap";
                        treeList.Add(subTree3);
                    }
                }
            }

            return treeList;
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = _bpeVa004Bll.GetPageList(pagination, queryJson);
            var entities = data as BpeVa004Model[] ?? data.ToArray();
            var jsonData = new
            {
                rows = entities,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(jsonData.ToJson());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetEntityJson(string keyValue)
        {
            var entity = _bpeVa004Bll.GetRecord(keyValue);
            return ToJsonResult(entity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetRecordModelJson(string keyValue)
        {
            var entity = _bpeVa004Bll.GetRecordModel(keyValue);
            return ToJsonResult(entity);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(BpeVa004Entity entity)
        {
            _bpeVa004Bll.AddOrUpdateRecord(entity);
            return Success("操作成功");
        }
    }
}