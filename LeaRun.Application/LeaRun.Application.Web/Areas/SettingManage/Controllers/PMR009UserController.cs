using LeaRun.Application.Busines.AuthorizeManage;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Cache;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.AuthorizeManage;
using LeaRun.Application.Entity.BaseManage;
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
    /// 
    /// </summary>
    public class PMR009UserController : MvcControllerBase
    {
        private SystemBLL sysBLL = new SystemBLL();
        DictionaryCache codeCache = new DictionaryCache();
        private UserBLL userBLL = new UserBLL();
        private ModuleFormInstanceBLL moduleFormInstanceBll = new ModuleFormInstanceBLL();

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

        /// <summary>
        /// 分配帐号
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult UserForm()
        {
            return View();
        }
        #endregion

        /// <summary>
        /// 科室列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回机构+科室树形Json</returns>

        #region 获取数据
        public ActionResult GetMorTreeJson(string value)
        {
            var mordata = sysBLL.GetOrgs(null).ToList();
            string parentId = value == null ? "ROOT" : value;
            var orgdata = sysBLL.GetPMR002MorDeptList(parentId).ToList();
            var organizedata = sysBLL.Get005Orgs(null).ToList();
            var offiecesdata = sysBLL.GetPMR008OffiecesList();
            var treeList = new List<TreeEntity>();
            foreach (PMR001MorEntity item in mordata)
            {
                #region 机构
                TreeEntity tree = new TreeEntity();
                bool hasChildren = false;
                if (hasChildren == false)
                {
                    hasChildren = orgdata.Count(t => t.ORGID == item.ORGID) == 0 ? false : true;
                    if (hasChildren == false)
                    {
                        hasChildren = organizedata.FirstOrDefault() != null;
                        if (hasChildren == false)
                        {                          
                            continue;
                        }
                    }
                }
                tree.id = item.ORGID;
                tree.text = item.ORGNAME;
                tree.value = item.ORGID;
                tree.parentId = item.PID == "ROOT" ? "0" : item.PID;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                //tree.AttributeValue = "Organize-" + item.ID;
                tree.AttributeValue = "Mor";
                treeList.Add(tree);
                #endregion
            }
            foreach (PMR002MorDeptEntity item in orgdata)
            {
                #region 部门
                TreeEntity tree = new TreeEntity();
                bool hasChildren = orgdata.Count(t => t.PARENTDEPT == item.DEPTID) == 0 ? false : true;
                tree.id = item.DEPTID;
                tree.text = item.DEPTNAME;
                tree.value = item.DEPTID;
                if (item.PARENTDEPT == "ROOT")
                {
                    tree.parentId = item.ORGID;
                }
                else
                {
                    tree.parentId = item.PARENTDEPT;
                }
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                //tree.AttributeValue = "Department-" + item.ORGID;
                tree.AttributeValue = "Department";
                treeList.Add(tree);
                #endregion
            }
          
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
                //tree.parentId = item.PARENTORG == "ROOT" ? "0" : item.PARENTORG;
                if (item.PARENTORG == "ROOT")
                {
                    if(mordata!=null&&mordata.Count>0)
                    {
                        tree.parentId = mordata.FirstOrDefault().ORGID;
                    }
                    else
                    {
                        tree.parentId = "0";
                    }
                    
                }
                else
                {
                    tree.parentId = item.PARENTORG;
                }
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
                bool hasChildren = false;
                tree.id = item.ID;
                tree.text = item.OFFICENAME;
                tree.value = item.ID;
                tree.parentId = item.ORGID;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Department";
                treeList.Add(tree);
                #endregion
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 分页获取机构注册表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            IEnumerable<PMR009UserEntity> data = null;
            var sexcodes= codeCache.GetStandardCodeList("性别代码");
            var postcodes = codeCache.GetStandardCodeList("医院人员岗位代码");
            if (!string.IsNullOrEmpty(queryJson))
            {
                data = sysBLL.GetPMR009UserList(pagination, queryJson);
                if(data!=null&&data.Count()>0)
                {
                    foreach(var d in data)
                    {
                        d.SEXNAME = sexcodes.Where(x => x.CODE == d.SEX).Select(x => x.NAME).FirstOrDefault();
                        d.POSTNAME = postcodes.Where(x => x.CODE == d.POST).Select(x => x.NAME).FirstOrDefault();
                    }
                }
            }
          
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
        /// 机构实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = sysBLL.GetPMR009UserEntity(keyValue);
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
            sysBLL.RemovePMR009UserForm(keyValue);
            return Success("删除成功。");
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="keyValue"></param>
       /// <param name="userEntity"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, PMR009UserEntity userEntity)
        {
            sysBLL.SavePMR009UserForm(keyValue, userEntity);
            return Success("操作成功。");
        }

        /// <summary>
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveUserForm(string keyValue, string strUserEntity, string FormInstanceId, string strModuleFormInstanceEntity)
        {
            UserEntity userEntity = strUserEntity.ToObject<UserEntity>();
            ModuleFormInstanceEntity moduleFormInstanceEntity = strModuleFormInstanceEntity.ToObject<ModuleFormInstanceEntity>();

            userEntity.CreateUserId = SystemInfo.CurrentUserId;
            string objectId = userBLL.SaveForm(keyValue, userEntity);
            moduleFormInstanceEntity.ObjectId = objectId;
            moduleFormInstanceBll.SaveEntity(FormInstanceId, moduleFormInstanceEntity);
            return Success("操作成功。");
        }
        #endregion

    }
}
