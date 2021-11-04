using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DataItemTypeManageController : MvcControllerBase
    {
        private readonly BpcSm002BLL _bpcSm002Bll = new BpcSm002BLL();
        //
        // GET: /CJManage/CjDataItemTypeManage/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditDataItemType(string keyValue)
        {
            return View();
        }

        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult AddDataItemType(string keyValue)
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
            _bpcSm002Bll.DeleteRecord(keyValue);
            return Success("删除成功");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = _bpcSm002Bll.GetPageList(pagination, queryJson);
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

        private void FillEntities(IEnumerable<BpcSM002Entity> entities)
        {
            var dataList = _bpcSm002Bll.GetList().ToList();
            foreach (var e in entities)
            {
                var item = dataList.Find(d => d.TYPEID == e.PARENT);
                if (item != null)
                {
                    e.ParentName = item.NAME;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="???"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCategoryTreeJson(bool addRoot = false)
        {
            var dataItemList = GetTreeList(true);
            AddTreeRoot(dataItemList);

            return Content(dataItemList.TreeToJson());
        }

        private void AddTreeRoot(List<TreeEntity> dataItemList)
        {
            TreeEntity tree = new TreeEntity();
            tree.id = "root";
            tree.text = "所有分类";
            tree.value = "0";
            tree.isexpand = true;
            tree.complete = true;
            //tree.showcheck = true;
            tree.hasChildren = true;
            tree.parentId = "0";
            tree.Attribute = "grade";
            tree.AttributeValue = "0";
            tree.img = "fa fa-sitemap";
            dataItemList.Add(tree);
        }

        private List<TreeEntity> GetTreeList(bool addRoot)
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
                //tree.showcheck = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.GRADE == "1" ? (addRoot ? "root" : "0") : item.PARENT;
                tree.img = "fa fa-sitemap";
                tree.Attribute = "grade";
                tree.AttributeValue = item.GRADE;
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
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDataItemJson(string keyValue)
        {
            var entity = _bpcSm002Bll.GetEntity(keyValue);
            return ToJsonResult(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(BpcSM002Entity entity)
        {
            _bpcSm002Bll.AddOrUpdateRecord( entity);
            return Success("操作成功");
        }
    }
}