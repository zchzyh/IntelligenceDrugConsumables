using System.Collections.Generic;
using System.Linq;
using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using LeaRun.Util;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util.Extension;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 采集权限分配
    /// </summary>
    public class AuthAssignManageController : MvcControllerBase
    {
        private readonly BpcSp005Bll _bpcSp005Bll = new BpcSp005Bll();
        private readonly BpcSp003BLL _bpcSp003Bll = new BpcSp003BLL();
        private readonly BpcSm002BLL _bpcSm002Bll = new BpcSm002BLL();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            var yearObject = new BpcSp003BLL().GetActiveYearSetting();
            ViewBag.ActionYear = yearObject.JXBM;
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var list = _bpcSp005Bll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = list,
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
        /// <param name="userId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public ActionResult GetAuthTreeList(string userId, string year)
        {
            var tableTypes = _bpcSm002Bll.GetList("1", "").ToList();
            //var year = _bpcSp003Bll.GetActiveYearSetting().JXND;
            var yearTables = _bpcSp003Bll.GetTableListByYear(year).ToList();
            var userTables = _bpcSp005Bll.GetUserTableList(year, userId).ToList();
            var treeEntites = FillYearTreeTable(tableTypes, yearTables);
            FillCheckTable(treeEntites, userTables);
            return Content(treeEntites.TreeToJson());
        }

        private List<TreeEntity> FillYearTreeTable(List<BpcSM002Entity> tableTypes, List<BpcSp001Entity> yearTables)
        {
            //var tableTypes = _bpcSm002Bll.GetList("1", "").ToList();
            //var tableList = _bpcSp001Bll.GetList();
            var treeList = new List<TreeEntity>();

            //过滤列表
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    tableList = tableList.Where(t => t.CJBMC.Contains(keyword) || t.CJBQM.Contains(keyword)).ToList();
            //}
            foreach (var item in tableTypes)
            {
                var tbList = yearTables.Where(t => t.SSLB == item.TYPEID).ToList();

                TreeEntity tree = new TreeEntity();
                bool hasChildren = yearTables.Count(t => t.SSLB == item.TYPEID) == 0 ? false : true;
                if (!hasChildren)
                {
                    //不显示没有表的分类
                    continue;
                }

                tree.id = "C_" + item.TYPEID;
                tree.text = item.NAME.Trim();
                tree.value = "0";
                tree.isexpand = true;
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
        /// 
        /// </summary>
        /// <param name="treeEntites"></param>
        /// <param name="userTables"></param>
        /// <returns></returns>
        public void FillCheckTable(List<TreeEntity> treeEntites, List<BpcSp005Entity> userTables)
        {
            foreach (var item in treeEntites)
            {
                if (userTables.Exists(t => t.CJBBM == item.id))
                {
                    item.checkstate = 1;
                    var parentItem = treeEntites.FirstOrDefault(l => l.id == item.parentId);
                    if (parentItem != null) parentItem.checkstate = 1;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tableIds"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveData(string userId, string year, string tableIds)
        {
            if (userId.IsEmpty())
            {
                return Error("请选择要分配的用户");
            } 
            var entities = new List<BpcSp005Entity>();
            string[] tbids = tableIds.Split(',');
            foreach (var id in tbids)
            {
                if (id.IsEmpty()) continue;
                if (id == "0" || id.IsEmpty()) continue;
                BpcSp005Entity entity = new BpcSp005Entity {ND = year, CJBBM = id};
                entities.Add(entity);
            }

            _bpcSp005Bll.SaveData(year, userId, entities);
            return Success("操作成功");
        }
    }
}