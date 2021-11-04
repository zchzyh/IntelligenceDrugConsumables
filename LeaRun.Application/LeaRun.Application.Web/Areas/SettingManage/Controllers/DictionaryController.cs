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
    /// 字典设置
    /// </summary>
    public class DictionaryController : MvcControllerBase
    {
        private readonly DictionaryBLL dictionaryBLL = new DictionaryBLL();
        DictionaryCache codeCache = new DictionaryCache();
        #region 视图功能
        /// <summary>
        /// 基础代码管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 基础代码表单
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult CodeForm(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                switch (type.ToLower())
                {
                    case "type":
                        return View("CodeTypeForm");
                    case "version":
                        return View("CodeVersionForm");
                    case "code":
                        return View("CodeForm");
                    default:
                        break;
                }
            }
            return Error("未选定类型。");
        }
        #endregion

        #region 获取数据
        #region 类别
        /// <summary>
        /// 获取或查找基础类别
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult GetCodeTypeList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = dictionaryBLL.GetStandardTypes(pagination, queryJson);
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
        /// 依据主键获取基础类别
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        ActionResult GetCodeTypeForm(string keyValue)
        {
            var data = dictionaryBLL.GetStandardTypeEntity(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 版本号
        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult GetCodeVersionList(string typeId)
        {
            var watch = CommonHelper.TimerStart();
            var data = dictionaryBLL.GetStandardVers(typeId);
            var JsonData = new
            {
                rows = data,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }

        /// <summary>
        /// 依据主键和类别编码获取版本号
        /// </summary>
        /// <param name="verId"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult GetCodeVersionForm(string verId, string typeId)
        {
            var data = dictionaryBLL.GetStandardVerEntity(typeId, verId);
            return Content(data.ToJson());
        }
        #endregion

        #region 编码
        /// <summary>
        /// 获取或查找编码
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult GetCodeList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = dictionaryBLL.GetStandardCodes(pagination, queryJson);
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
        /// 根据类别名称获取标准编码
        /// </summary>
        /// <param name="TypeName">类别名称</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GeCodeListJson(string TypeName)
        {
            var data = codeCache.GetStandardCodeList(TypeName);
            return Content(data.ToJson());
        }

        /// <summary>
        /// 根据类别编码，版本号，主键获取编码
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="verId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult GetCodeForm(string typeId, string verId, string code)
        {
            var data = dictionaryBLL.GetStandardCodeEntity(typeId, verId, code);
            return Content(data.ToJson());
        }
        #endregion

        #region 行政区域
        /// <summary>
        /// 获取行政区域树形结构
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public ActionResult GetPMR025UnitTreeJson(string keyword)
        {
            var data = codeCache.GetPMR025UnitList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.NAME.Contains(keyword), "UNITID");
            }
            var treeList = new List<TreeEntity>();
            foreach (PMR025UnitEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.PID == item.UNITID) == 0 ? false : true;
                tree.id = item.UNITID;
                tree.text = item.NAME;
                tree.value = item.UNITID;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.PID== "ROOT"?"0": item.PID;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        #endregion
        #endregion

        #region 提交数据
        #region 类别
        /// <summary>
        /// 保存基础类别
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="s101TypeEntity"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult SaveCodeType(string keyValue, S101TypeEntity s101TypeEntity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                dictionaryBLL.CreateStandardTypeForm(s101TypeEntity);
            }
            else
            {
                dictionaryBLL.ModifyStandardTypeForm(keyValue, s101TypeEntity);
            }
            return Success("操作成功。");
        }

        /// <summary>
        /// 删除基础类别
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DeleteCodeType(string typeId)
        {
            dictionaryBLL.RemoveStandardTypeForm(typeId);
            return Success("操作成功。");
        }

        /// <summary>
        /// 启用类别
        /// </summary>
        /// <param name="active"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ActiveType(bool active, string typeId)
        {
            S101TypeEntity temp = dictionaryBLL.GetStandardTypeEntity(typeId);
            temp.STATUS = active ? "1" : "0";
            dictionaryBLL.ModifyStandardTypeForm(typeId, temp);
            return Success("操作成功。");
        }
        #endregion

        #region 版本号
        /// <summary>
        /// 保存版本号
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="versionId"></param>
        /// <param name="s102VerEntity"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult SaveCodeVersion(string typeId, string versionId, S102VerEntity s102VerEntity)
        {
            if (string.IsNullOrEmpty(versionId))
            {
                dictionaryBLL.CreateStandardVerForm(s102VerEntity);
            }
            else
            {
                dictionaryBLL.ModifyStandardVerForm(typeId, versionId, s102VerEntity);
            }
            return Success("操作成功。");
        }

        /// <summary>
        /// 删除版本号
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="verId"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DeleteCodeVersion(string typeId, string verId)
        {
            dictionaryBLL.RemoveStandardVerForm(typeId, verId);
            return Success("操作成功。");
        }

        /// <summary>
        /// 启用版本号
        /// </summary>
        /// <param name="active"></param>
        /// <param name="typeId"></param>
        /// <param name="verId"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ActiveVersion(bool active, string typeId, string verId)
        {
            S102VerEntity temp = dictionaryBLL.GetStandardVerEntity(typeId, verId);
            temp.STATUS = active ? "1" : "0";
            dictionaryBLL.ModifyStandardVerForm(typeId, verId, temp);
            return Success("操作成功。");
        }
        #endregion

        #region 编码
        /// <summary>
        /// 保存编码
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="verId"></param>
        /// <param name="codeId"></param>
        /// <param name="s103CodeEntity"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult SaveCode(string typeId, string verId, string codeId, S103CodeEntity s103CodeEntity)
        {
            if (string.IsNullOrEmpty(codeId))
            {
                dictionaryBLL.CreateStandardCodeForm(s103CodeEntity);
            }
            else
            {
                dictionaryBLL.ModifyStandardCodeForm(typeId, verId, codeId, s103CodeEntity);
            }
            return Success("操作成功。");
        }

        /// <summary>
        /// 删除编码
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="verId"></param>
        /// <param name="codeId"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DeleteCode(string typeId, string verId, string codeId)
        {
            List<string> codes = codeId.Split(',').ToList();
            foreach (string code in codes)
            {
                dictionaryBLL.RemoveStandardCodeForm(typeId, verId, code);
            }
            return Success("操作成功。");
        }

        /// <summary>
        /// 启用编码
        /// </summary>
        /// <param name="active"></param>
        /// <param name="typeId"></param>
        /// <param name="verId"></param>
        /// <param name="codeId"></param>
        /// <returns></returns>
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ActiveCode(bool active, string typeId, string verId, string codeId)
        {
            List<string> codes = codeId.Split(',').ToList();
            foreach (string code in codes)
            {
                S103CodeEntity temp = dictionaryBLL.GetStandardCodeEntity(typeId, verId, code);
                temp.STATUS = active ? "1" : "0";
                dictionaryBLL.ModifyStandardCodeForm(typeId, verId, code, temp);
            }
            return Success("操作成功。");
        }
        #endregion
        #endregion
    }
}
