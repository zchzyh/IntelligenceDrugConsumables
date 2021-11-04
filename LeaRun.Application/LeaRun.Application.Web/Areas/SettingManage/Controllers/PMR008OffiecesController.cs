using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Cache;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util;  //ToJson
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace LeaRun.Application.Web.Areas.SettingManage.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PMR008OffiecesController : MvcControllerBase
    {
        private SystemCache sysCache = new SystemCache();
        private SystemBLL sysBLL = new SystemBLL();
        //private DepartmentCache departmentCache = new DepartmentCache();

        #region 视图功能
        /// <summary>
        /// 科室管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 科室表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 科室列表 
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string organizeId, string keyword)
        {
            //var data = departmentCache.GetList(organizeId).ToList();
            var data = sysBLL.Get005Orgs(null).ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.MANAGERORGNAME.Contains(keyword), "ORGID");
            }
            var treeList = new List<TreeEntity>();
            foreach (PMR005OrgEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.PARENTORG == item.ORGID) == 0 ? false : true;
                tree.id = item.ORGID;
                tree.text = item.MANAGERORGNAME;
                tree.value = item.ORGID;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.PARENTORG == "ROOT" ? "0" : item.PARENTORG;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 科室列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回机构+科室树形Json</returns>
        public ActionResult GetOrganizeTreeJson(string keyword)
        {
            //var organizedata = organizeCache.GetList();
            var organizedata = sysBLL.Get005Orgs(null).ToList();
            //var departmentdata = departmentBLL.GetList();
            var offiecesdata = sysBLL.GetPMR008OffiecesList();
            var treeList = new List<TreeEntity>();
            foreach (PMR005OrgEntity item in organizedata)
            {
                #region 机构
                TreeEntity tree = new TreeEntity();
                bool hasChildren = organizedata.Count(t => t.PARENTORG == item.ORGCODE) == 0 ? false : true;
                if (hasChildren == false)
                {
                    hasChildren = offiecesdata.Count(t => t.ORGID == item.ORGID) == 0 ? false : true;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
                tree.id = item.ORGCODE;
                tree.text = item.MANAGERORGNAME;
                tree.value = item.ORGCODE;
                //tree.parentId = item.PARENTORG;
                tree.parentId = item.PARENTORG == "ROOT" ? "0" : item.PARENTORG;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Organize";
                treeList.Add(tree);
                #endregion
            }
            foreach (PMR008OffiecesEntity item in offiecesdata)
            {
                #region 部门
                TreeEntity tree = new TreeEntity();
                //bool hasChildren = departmentdata.Count(t => t.ParentId == item.DepartmentId) == 0 ? false : true;
                bool hasChildren = false;
                tree.id = item.ID;
                tree.text = item.OFFICENAME;
                tree.value = item.ID;
                //if (item.ParentId == "0")
                //{
                    //tree.parentId = item.OrganizeId;
                tree.parentId = item.ORGID;
                //}
                //else
                //{
                //    tree.parentId = item.ParentId;
                //}
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Department";
                treeList.Add(tree);
                #endregion
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                treeList = treeList.TreeWhere(t => t.text.Contains(keyword), "id", "parentId");
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 科室列表 
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetTreeListJson(string condition, string keyword)
        {
         
            var organizedata = sysBLL.Get005Orgs(null).ToList();
            var offiecesdata = sysBLL.GetPMR008OffiecesList().ToList();
            if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(keyword))
            {
                #region 多条件查询
                switch (condition)
                {
                    case "OFFICENAME":    //科室名称
                        offiecesdata = offiecesdata.TreeWhere(t => t.OFFICENAME.Contains(keyword), "ID");
                        break;
                    case "OFFICECODE":      //科室编号
                        offiecesdata = offiecesdata.TreeWhere(t => t.OFFICECODE.Contains(keyword), "ID");
                        break;                  
                    default:
                        break;
                }
                #endregion
            }
            var treeList = new List<TreeGridEntity>();
            foreach (PMR005OrgEntity item in organizedata)
            {
                TreeGridEntity tree = new TreeGridEntity();
                bool hasChildren = organizedata.Count(t => t.PARENTORG == item.ORGCODE) == 0 ? false : true;
                if (hasChildren == false)
                {
                    //hasChildren = departmentdata.Count(t => t.OrganizeId == item.OrganizeId) == 0 ? false : true;
                    hasChildren = offiecesdata.Count(t => t.ORGID == item.ORGCODE) == 0 ? false : true;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
                tree.id = item.ORGCODE;
                tree.hasChildren = hasChildren;
                //tree.parentId = item.PARENTORG;
                tree.parentId = item.PARENTORG == "ROOT" ? "0" : item.PARENTORG;
                tree.expanded = true;
                item.CREATOR = "";
                string ORGID = item.ORGID;
                item.ORGID = item.ORGCODE;
                //item.EnCode = ""; item.ShortName = ""; item.Nature = ""; item.Manager = ""; item.OuterPhone = ""; item.InnerPhone = ""; item.Description = "";
                string itemJson = item.ToJson();
                //itemJson = itemJson.Insert(1, "\"DepartmentId\":\"" + item.OrganizeId + "\",");
                itemJson = itemJson.Insert(1, "\"ID\":\"" + ORGID + "\",");
                itemJson = itemJson.Insert(1, "\"OFFICENAME\":\"" + item.MANAGERORGNAME + "\",");
                itemJson = itemJson.Insert(1, "\"Sort\":\"PMR005_ORG\",");
                tree.entityJson = itemJson;
                treeList.Add(tree);
            }
            foreach (PMR008OffiecesEntity item in offiecesdata)
            {
                TreeGridEntity tree = new TreeGridEntity();
                bool hasChildren = organizedata.Count(t => t.PARENTORG == item.ORGID) == 0 ? false : true;
                tree.id = item.ID;
                //if (item.ParentId == "0")
                //{
                    //tree.parentId = item.OrganizeId;
                    tree.parentId = item.ORGID;
                //}
                //else
                //{
                //    tree.parentId = item.ParentId;
                //}
                tree.expanded = true;
                tree.hasChildren = hasChildren;
                string itemJson = item.ToJson();
                itemJson = itemJson.Insert(1, "\"Sort\":\"PMR008_OFFIECES\",");
                tree.entityJson = itemJson;
                treeList.Add(tree);
            }
            return Content(treeList.TreeJson());
        }
        /// <summary>
        /// 科室实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            //var data = departmentBLL.GetEntity(keyValue);
            var data = sysBLL.GetPMR008OffiecesEntity(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 科室编号不能重复
        /// </summary>
        /// <param name="EnCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistEnCode(string EnCode, string keyValue)
        {
            //bool IsOk = departmentBLL.ExistEnCode(EnCode, keyValue);
            bool IsOk = sysBLL.ExistPMR008OffiecesEnCode(EnCode, keyValue);
            return Content(IsOk.ToString());
        }
        /// <summary>
        /// 科室名称不能重复
        /// </summary>
        /// <param name="FullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistFullName(string FullName, string keyValue)
        {
            //bool IsOk = departmentBLL.ExistFullName(FullName, keyValue);
            bool IsOk = sysBLL.ExistPMR008OffiecesFullName(FullName, keyValue);
            return Content(IsOk.ToString());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            //departmentBLL.RemoveForm(keyValue);
            sysBLL.RemovePMR008OffiecesForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存科室表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="offiecesEntity">科室实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, PMR008OffiecesEntity offiecesEntity)
        {
 
            sysBLL.SavePMR008OffiecesForm(keyValue, offiecesEntity);
            return Success("操作成功。");
        }
        #endregion

    }
}
