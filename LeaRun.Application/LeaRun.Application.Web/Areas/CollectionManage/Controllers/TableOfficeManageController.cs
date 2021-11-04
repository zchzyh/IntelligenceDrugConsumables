using System.Collections.Generic;
using System.Linq;
using LeaRun.Application.Code;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using LeaRun.Util;
using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Util.Extension;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 采集表年度管理
    /// </summary>
    public class TableOfficeManageController : MvcControllerBase
    {
        private readonly BpcSp001Bll _bpcSp001Bll = new BpcSp001Bll();
        private readonly BpcSm002BLL _bpcSm002Bll = new BpcSm002BLL();
        private readonly BpcSp003BLL _bpcSp003Bll = new BpcSp003BLL();
        private readonly SystemBLL _systemBll = new SystemBLL();
        private readonly BpcSp008Bll _bpcSp008Bll = new BpcSp008Bll();
        
        #region 视图功能

        /// <summary>
        /// 采集表年度管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region 获取数据

        #region 医疗机构科室信息列表

        /// <summary>
        /// 医疗机构科室信息列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var list = _systemBll.GetPageList(pagination, queryJson);
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

        #endregion

        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetOrgsJson()
        {
            var orgs = _systemBll.Get005Orgs(null).Where(o => o.FLAG == "1");
            return ToJsonResult(orgs);
        }


        /// <summary>
        /// 年度管理树列表
        /// </summary>
        /// <param name="officeCode"></param>
        /// <returns></returns>
        public ActionResult GetTreeListForOffice(string officeId,string tableName)
        {
            var yearObject = _bpcSp003Bll.GetActiveYearSetting(); 
            var treeList = GetTreeList(yearObject.JXND,tableName);
            //var yearTables = _bpcSp003Bll.GetListByYear(yearObject.JXND).ToList();
             var officeTables = officeId.IsEmpty()?new List<BpcSp008Entity>() : _bpcSp008Bll.GetList().Where(m=>m.DWCSBM== officeId).ToList();
            foreach (var item in treeList)
            {
                if (officeTables.Exists(t => t.CJBBM == item.id))
                {
                    item.checkstate = 1;
                    var parentItem = treeList.FirstOrDefault(l => l.id == item.parentId);
                    if (parentItem != null)
                    {
                        parentItem.checkstate = 1;
                        parentItem.isexpand = true;
                    }
                }
            }

            return Content(treeList.TreeToJson());
        }
        private List<TreeEntity> GetTreeList(string year,string tableName)
        {
            var tableTypes = _bpcSm002Bll.GetList("1", "").ToList();
           //var tableList = _bpcSp001Bll.GetList();
            var tableList = _bpcSp003Bll.GetTableListByYear(year).ToList();
            var treeList = new List<TreeEntity>();

            foreach (var item in tableTypes)
            {
                var tbList = tableList.Where(t => t.SSLB == item.TYPEID).ToList();
                TreeEntity tree = new TreeEntity();
                bool hasChildren = tableList.Count(t => t.SSLB == item.TYPEID) == 0 ? false : true;
                if (!hasChildren)
                {
                    continue;
                }
                tree.id = "C_" + item.TYPEID;
                tree.text =item.NAME.Trim();
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
                    subTree.text = tableName.IsEmpty()? tb.CJBMC.Trim(): tb.CJBMC.Contains(tableName)?$"<font color=red>{tb.CJBMC.Trim()}</font>": tb.CJBMC.Trim();
                    subTree.value = tb.CJBBM;
                    subTree.isexpand = true;
                    subTree.complete = true;
                    subTree.showcheck = true;
                    subTree.hasChildren = false;
                    subTree.parentId = tree.id;
                    subTree.title = tb.CJBQM.Trim();
                    if (subTree.text.IndexOf("<font") >= 0)
                    {
                        //搜索
                        tree.isexpand = true;
                    }
                    //tree.img = "fa fa-sitemap";
                    treeList.Add(subTree);
                }
            }

            return treeList;
        }
        #endregion




        #region 保存数据

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="officeCode">科室名称</param>
        /// <param name="tableIds">多个表Id,用逗号分隔</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveData(string orgId,string officeId, string tableIds)
        {
            if (officeId.IsEmpty())
            {
                return Error("请选择科室");
            }

            var entities = new List<BpcSp008Entity>();
            var tbIds = tableIds.Split(',');
            foreach (var id in tbIds)
            {
                if (id.Length <= 3)
                    continue;
                var entity = new BpcSp008Entity { CJBBM = id, DWCSBM = officeId, OrgId = orgId,DWSCLX= "3" };
                entities.Add(entity);
            }

            _bpcSp008Bll.AddOrUpdateRecords(orgId, officeId, entities);
            return Success("操作成功");
        }

        #endregion
    }
}