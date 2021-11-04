using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.SettingManage.Controllers
{
    /// <summary>
    /// 主管机构部门
    /// </summary>
    public class PMR002MorDeptController : MvcControllerBase
    {
        private SystemBLL sysBLL = new SystemBLL();
        #region 视图功能
        /// <summary>
        /// 主管机构部门管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 主管机构部门表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 主管机构部门详细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Detail()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 主管机构部门列表 
        /// </summary>
        /// <param name="value">当前主键</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string value)
        {
            string parentId = value == null ? "ROOT" : value;
            //var filterdata = areaBLL.GetList(parentId).ToList();
            var filterdata = sysBLL.GetPMR002MorDeptList(parentId).ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (filterdata.Count > 0)
            {
                foreach (PMR002MorDeptEntity item in filterdata)
                {
                    bool hasChildren = sysBLL.GetPMR002MorDeptList(item.DEPTID).ToList().Count == 0 ? false : true;
                    sb.Append("{");
                    sb.Append("\"id\":\"" + item.DEPTID + "\",");
                    sb.Append("\"text\":\"" + item.DEPTNAME + "\",");
                    sb.Append("\"value\":\"" + item.DEPTID + "\",");
                    sb.Append("\"isexpand\":false,");
                    sb.Append("\"complete\":false,");
                    sb.Append("\"hasChildren\":" + hasChildren.ToString().ToLower() + "");
                    sb.Append("},");
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return Content(sb.ToString());
        }
        /// <summary>
        /// 科室列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回机构+科室树形Json</returns>
        public ActionResult GetMorTreeJson(string value)
        {
            //var organizedata = organizeCache.GetList();
            var mordata = sysBLL.GetOrgs(null).ToList();
            //var departmentdata = departmentBLL.GetList();
            //var offiecesdata = sysBLL.GetPMR008OffiecesList();
            string parentId = value == null ? "ROOT" : value;
            //var filterdata = areaBLL.GetList(parentId).ToList();
            var filterdata = sysBLL.GetPMR002MorDeptList(parentId).ToList();
            var treeList = new List<TreeEntity>();
            foreach (PMR001MorEntity item in mordata)
            {
                #region 机构
                TreeEntity tree = new TreeEntity();
                //bool hasChildren = organizedata.Count(t => t.PARENTORG == item.ORGCODE) == 0 ? false : true;
                bool hasChildren = false;
                if (hasChildren == false)
                {
                    //hasChildren = offiecesdata.Count(t => t.ORGID == item.ORGID) == 0 ? false : true;
                    hasChildren = filterdata.Count(t => t.ORGID == item.ORGID) == 0 ? false : true;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
                tree.id = item.ORGID;
                tree.text = item.ORGNAME;
                tree.value = item.ORGID;
                //tree.parentId = item.PARENTORG;
                tree.parentId = item.PID == "ROOT" ? "0" : item.PID;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Organize-" + item.ID;
                treeList.Add(tree);
                #endregion
            }
            foreach (PMR002MorDeptEntity item in filterdata)
            {
                #region 部门
                TreeEntity tree = new TreeEntity();
                bool hasChildren = filterdata.Count(t => t.PARENTDEPT == item.DEPTID) == 0 ? false : true;
                tree.id = item.DEPTID;
                tree.text = item.DEPTNAME;
                tree.value = item.DEPTID;
                if (item.PARENTDEPT == "ROOT")
                {
                    tree.parentId = item.ORGID;
                    //tree.parentId = item.ORGID;
                }
                else
                {
                    tree.parentId = item.PARENTDEPT;
                }
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Department-" +item.ORGID;
                //tree.AttributeValue = item.ToJson();
                treeList.Add(tree);
                #endregion
            }
           
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 主管机构部门列表
        /// </summary>
        /// <param name="value">当前主键</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string value, string keyword)
        {
            string parentId = value == null||value=="0" ? "ROOT" : value;
            var data = sysBLL.GetPMR002MorDeptList(parentId, keyword).ToList();
            return Content(data.ToJson());
        }
        /// <summary>
        /// 主管机构部门列表（主要是绑定下拉框）
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetAreaListJson(string parentId)
        {
            var data = sysBLL.GetPMR002MorDeptList(parentId == null ? "0" : parentId);
            return Content(data.ToJson());
        }
        /// <summary>
        /// 主管机构部门实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = sysBLL.GetPMR002MorDeptEntity(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除主管机构部门
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            sysBLL.RemovePMR002MorDeptForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存主管机构部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="deptEntity">机构部门实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, PMR002MorDeptEntity deptEntity)
        {
            deptEntity.PARENTDEPT=deptEntity.PARENTDEPT=="0"?"ROOT":deptEntity.PARENTDEPT;
            sysBLL.SavePMR002MorDeptForm(keyValue, deptEntity);
            return Success("操作成功。");
        }
        #endregion

    }
}
