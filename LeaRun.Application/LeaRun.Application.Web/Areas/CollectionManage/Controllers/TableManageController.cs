using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Util;
using LeaRun.Application.Cache;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Busines.SettingManage;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 采集表信息管理
    /// </summary>
    public class TableManageController : MvcControllerBase
    {
        private readonly BpcSp001Bll _bpcSp001Bll = new BpcSp001Bll();
        private readonly BpcSp003BLL _bpcSp003Bll = new BpcSp003BLL();
        private readonly BpcSm002BLL _bpcSm002Bll = new BpcSm002BLL();
        private readonly DictionaryBLL _dictionaryBll = new DictionaryBLL();

        #region 视图功能

        /// <summary>
        /// 采集表信息管理
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
        public ActionResult EditTable(string keyValue)
        {
            return View();
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="grade">级别</param>
        /// <param name="parentId">父节点</param>
        /// <param name="forSearch"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDataCategoryListJson(string grade = "", string parentId = "", bool forSearch = false)
        {
            var list = _bpcSm002Bll.GetList(grade, parentId);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "全部");
            foreach (var item in list)
            {
                items.Add(item.TYPEID, item.NAME);
            }

            return ToJsonResult(SetComboBoxValue(items));
        }


        /// <summary>
        /// 获取采集表分页列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = _bpcSp001Bll.GetPageList(pagination, queryJson);
            var bpcSp001Entities = data as BpcSp001Entity[] ?? data.ToArray();
            FillEntities(bpcSp001Entities);
            var jsonData = new
            {
                rows = bpcSp001Entities,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(jsonData.ToJson());
        }

        private void FillEntities(IEnumerable<BpcSp001Entity> list)
        {
            var dataItemList = _dictionaryBll.GetStandardCodes("PMS.2001");
            //var dataItemList = _dataItemCache.GetDataItemList("CJPL");
            foreach (var entity in list)
            {
                var item = dataItemList.FirstOrDefault(l => l.CODE == entity.CJPL);
                if (item != null)
                {
                    entity.CJPLMC = item.NAME;
                }
            }
        }

        ///// <summary>
        ///// 采集频率字典列表
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult GetCjplListJson()
        //{
        //    var dataItemList = _dataItemCache.GetDataItemList("CJPL");
        //    return Content(dataItemList.ToJson());
        //}


        /// <summary>
        /// 获取采集表树列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTableTreeJson(string keyword)
        {
            var treeList = GetTreeList(keyword);

            return Content(treeList.TreeToJson());
        }


        private List<TreeEntity> GetTreeList(string keyword)
        {
            var tableTypes = _bpcSm002Bll.GetList("1", "").ToList();
            var tableList = _bpcSp001Bll.GetList();
            var treeList = new List<TreeEntity>();
            
            //过滤列表
            if (!string.IsNullOrEmpty(keyword))
            {
                tableList = tableList.Where(t => t.CJBMC.Contains(keyword) || t.CJBQM.Contains(keyword)).ToList();
            }

            foreach (var item in tableTypes)
            {
                var tbList = tableList.Where(t => t.SSLB == item.TYPEID).ToList();

                TreeEntity tree = new TreeEntity();
                bool hasChildren = tableList.Count(t => t.SSLB == item.TYPEID) == 0 ? false : true;
                tree.id = "C_" + item.TYPEID;
                tree.text = item.NAME.Trim();
                tree.value = item.TYPEID;
                tree.isexpand = false;
                tree.complete = true;
                tree.showcheck = true;
                tree.hasChildren = hasChildren;
                tree.parentId = "0";
                tree.img = "fa fa-sitemap";
                treeList.Add(tree);


                foreach (var tb in tbList)
                {
                    TreeEntity subTree = new TreeEntity();
                    subTree.id = tb.CJBBM;
                    subTree.text = tb.CJBMC.Trim();
                    subTree.value = tb.CJBBM;
                    subTree.isexpand = true;
                    subTree.complete = true;
                    subTree.showcheck = true;
                    subTree.hasChildren = false;
                    subTree.parentId = tree.id;
                    subTree.title = tb.CJBQM.Trim();
                    //tree.img = "fa fa-sitemap";
                    treeList.Add(subTree);
                }
            }

            return treeList;
        }


        /// <summary>
        /// 年度管理树列表
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public ActionResult GetTreeListForYear(string year)
        {
            var treeList = GetTreeList("");
            var yearTables = _bpcSp003Bll.GetListByYear(year).ToList();
            foreach (var item in treeList)
            {
                if (yearTables.Exists(t => t.CJBBM == item.id))
                {
                    item.checkstate = 1;
                    var parentItem = treeList.FirstOrDefault(l => l.id == item.parentId);
                    if (parentItem != null) parentItem.checkstate = 1;
                }
                ;
            }

            return Content(treeList.TreeToJson());
        }


        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetEntityJson(string keyValue)
        {
            var entity = _bpcSp001Bll.GetEntity(keyValue);
            return ToJsonResult(entity);
        }

        #endregion
        
        #region 提交数据

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="keyValue">主键值 </param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelRecord(string keyValue)
        {
            _bpcSp001Bll.DeleteRecord(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 编辑采集表状态
        /// </summary>
        /// <param name="keyValue">主键值 </param>
        /// <param name="enabled">是否有效</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ModifyStatus(string keyValue, bool enabled)
        {
            _bpcSp001Bll.ModifyStatus(keyValue, enabled);
            return Success("操作成功");
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(BpcSp001Entity entity)
        {
            _bpcSp001Bll.SaveForm(entity);
            return Success("操作成功");
        }

        #endregion
    }
}