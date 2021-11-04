using LeaRun.Application.Cache;
using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Util;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.Service.SettingManage;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 数据项信息管理
    /// </summary>
    public class DataItemManageController : MvcControllerBase
    {
        private readonly BpcSm001Bll _bpcSm001Bll = new BpcSm001Bll();
        private readonly BpcSm002BLL _bpcSm002Bll = new BpcSm002BLL();
        private readonly DictionaryBLL _dictionaryBll = new DictionaryBLL();
        
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
        public ActionResult EditDataItem(string keyValue)
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
        public ActionResult DelRecord(string keyValue)
        {
            _bpcSm001Bll.DeleteRecord(keyValue);
            return Success("删除成功");
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
            var data = _bpcSm001Bll.GetPageList(pagination, queryJson);
            FillEntities(data);
            var jsonData = new
            {
                rows = data,
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
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCategoryTreeJson(string keyword)
        {
            var dataItemList = GetTreeList(keyword);
            return Content(dataItemList.TreeToJson());
        }

        private List<TreeEntity> GetTreeList(string keyword)
        {
            var data = _bpcSm002Bll.GetList("", "");
            //var tableList = _bpcSp001Bll.GetList();
            var treeList = new List<TreeEntity>();

            ////过滤列表
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    tableList = tableList.Where(t => t.CJBMC.Contains(keyword) || t.CJBQM.Contains(keyword)).ToList();
            //}
            foreach (var item in data)
            {
                // var tbList = tableList.Where(t => t.SSLB == item.TYPEID).ToList();

                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.PARENT == item.TYPEID) == 0 ? false : true;
                tree.id = item.TYPEID;
                tree.text = item.NAME.Trim();
                tree.value = item.TYPEID;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.GRADE == "1" ? "0" : item.PARENT;
                tree.img = "fa fa-sitemap";
                treeList.Add(tree);


                //foreach (var tb in tbList)
                //{
                //    TreeEntity subTree = new TreeEntity();
                //    subTree.id = tb.CJBBM;
                //    subTree.text = tb.CJBMC.Trim();
                //    subTree.value = tb.CJBBM;
                //    subTree.isexpand = true;
                //    subTree.complete = true;
                //    subTree.showcheck = true;
                //    subTree.hasChildren = false;
                //    subTree.parentId = tree.id;
                //    subTree.title = tb.CJBQM.Trim();
                //    //tree.img = "fa fa-sitemap";
                //    treeList.Add(subTree);
                //}
            }

            return treeList;
        }


        /// <summary>
        /// 计算单位
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUnitJson()
        {
            var codeList = GetUnitList();// _dictionaryBll.GetStandardCodes("PMS.3001");
           return Content(codeList.ToJson());
        }

        /// <summary>
        /// 采集频率
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCjplJson()
        {
            var codeList = GetCjplList();
            return Content(codeList.ToJson());
        }

        /// <summary>
        /// 行列设置数据类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetColDataTypeJson()
        {
            var codeList = _dictionaryBll.GetStandardCodes("PMS.4096"); 
            return Content(codeList.ToJson());
        }
        /// <summary>
        /// 布局方式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetLayoutJson()
        {
            var codeList = _dictionaryBll.GetStandardCodes("PMS.4097");
            return Content(codeList.ToJson());
        } 


        private IEnumerable<S103CodeEntity> GetCjplList()
        {
            return _dictionaryBll.GetStandardCodes("PMS.2001");
        }

        private IEnumerable<S103CodeEntity> GetUnitList()
        {
            return _dictionaryBll.GetStandardCodes("PMS.3001");
        }
    

        private void FillEntities(IEnumerable<BpcSM001Entity> list)
        {
            var cjplDic = GetCjplList();// _dataItemCache.GetDataItemList("CJPL").ToList();
            var unitDic = GetUnitList();// _dataItemCache.GetDataItemList("Unit").ToList();
            var dataItemList = _bpcSm002Bll.GetList(); // _dataItemCache.GetDataItemList("CJPL");
            foreach (var entity in list)
            {
                var dicItem = cjplDic.FirstOrDefault(d => d.CODE == entity.YXPL);
                if (dicItem != null)
                {
                    entity.YxplName = dicItem.NAME;
                }

                var unitItem = unitDic.FirstOrDefault(d => d.CODE == entity.JLDW);
                if (unitItem != null)
                {
                    entity.JldwName = unitItem.NAME;
                }

                var item = dataItemList.FirstOrDefault(l => l.TYPEID == entity.TYPEID);
                if (item != null)
                {
                    if (item.GRADE != "1")
                    {
                        //二级
                        entity.SecondCategoryId = item.TYPEID;
                        entity.SecondCategory = item.NAME;

                        var parentItem = dataItemList.FirstOrDefault(d => d.TYPEID == item.PARENT);
                        if (parentItem != null)
                        {
                            entity.FirstCategoryId = parentItem.TYPEID;
                            entity.FirstCategory = parentItem.NAME;
                        }
                    }
                    else
                    {
                        entity.FirstCategoryId = item.TYPEID;
                        entity.FirstCategory = item.NAME;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDataItemJson(string keyValue)
        {
            var entity = _bpcSm001Bll.GetEntity(keyValue);
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
        public ActionResult SaveForm(BpcSM001Entity entity)
        {
            _bpcSm001Bll.AddorUpdateRecord(entity);
            return Success("操作成功");
        }
    }
}