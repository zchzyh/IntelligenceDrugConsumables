using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Cache;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.SettingManage.Controllers
{
    /// <summary>
    /// 机构管理
    /// </summary>
    public class PmrOrgController : MvcControllerBase
    {

        private SystemBLL sysBLL = new SystemBLL();

        #region 视图功能
        /// <summary>
        /// 机构管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 机构表单
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
        /// 分页获取机构注册表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = sysBLL.Get005Orgs(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }
        /// <summary>
        /// 医疗机构 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string keyword)
        {
            //var data = organizeCache.GetList().ToList();
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
                tree.parentId = item.PARENTORG=="ROOT"?"0": item.PARENTORG;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 机构实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = sysBLL.Get005OrgEntity(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 验证数据
        ///// <summary>
        ///// 公司名称不能重复
        ///// </summary>
        ///// <param name="organizeName">公司名称</param>
        ///// <param name="keyValue">主键</param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult ExistFullName(string FullName, string keyValue)
        //{
        //    bool IsOk = organizeBLL.ExistFullName(FullName, keyValue);
        //    return Content(IsOk.ToString());
        //}
        
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue)
        {
            sysBLL.Remove005OrgForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存机构表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="orgEntity">机构实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, PMR005OrgEntity orgEntity)
        {
            if(!string.IsNullOrEmpty(keyValue))
            {
                sysBLL.Modify005OrgForm(keyValue, orgEntity);
            }
            else
            {
                orgEntity.PARENTORG = string.IsNullOrEmpty(orgEntity.PARENTORG) ? "ROOT" : orgEntity.PARENTORG;
                sysBLL.Create005OrgtForm(orgEntity);
            }          
            return Success("操作成功。");
        }
        #endregion

    }
}
