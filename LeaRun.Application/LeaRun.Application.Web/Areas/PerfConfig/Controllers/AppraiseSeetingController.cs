using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfConfig.Controllers
{
    /// <summary>
    /// 绩效配置-评价设置
    /// </summary>
    public class AppraiseSeetingController : MvcControllerBase
    {
        AppraiseSeetingBLL bll;
        DictionaryBLL dicbll;
        /// <summary>
        /// 构造函数
        /// </summary>
        public AppraiseSeetingController()
        {
            bll = new AppraiseSeetingBLL();
            dicbll = new DictionaryBLL();
        }
        #region 评价方法设置
        #region 视图功能
        /// <summary>
        /// 评价方法设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 新增/修改评价方法
        /// </summary>
        /// <param name="keyValue">评价方法编号</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditAppraiseMothed(string keyValue)
        {
            return View();
        }

        #endregion 视图功能

        #region 获取数据
        /// <summary>
        /// 评价方式列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetAppraiseListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var metas = bll.GetAppraisedataList(pagination, queryJson);
            var JsonData = new
            {
                rows = metas,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }
        /// <summary>
        /// 获取评价方法的数据列表，给到编辑页面
        /// </summary>
        /// <param name="keyValue">评价方法编号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAppraiseData(string keyValue)
        {
            var meta = bll.GetAppraiseData(keyValue);
            return ToJsonResult(new
            {
                PJFFBH = meta.PJFFBH,
                PJFFMC = meta.PJFFMC,
                PJFFGZ = meta.PJFFGZ,
                STATUS = meta.STATUS,
                REMARK = meta.REMARK,
                CREATOR = meta.CREATOR
            });
        }
        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 提交保存评价方法数据
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveAppraiseData(BpeEA003Entity meta)
        {
            if (string.IsNullOrEmpty(meta.PJFFBH) || meta.PJFFBH.Contains("&nbsp;"))
                meta.PJFFBH = VerifyCode.GetRandomCode();
            if (string.IsNullOrEmpty(meta.CREATOR))
            {
                bll.AddAppraiseData(meta);
            }
            else
            {
                bll.ModifyAppraiseData(meta.PJFFBH, meta);
            }
            return Success("操作成功");
        }
        /// <summary>
        /// 删除评价方法
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelAppraiseData(string keyValue)
        {
            bll.RemoveAppraiseData(keyValue);
            return Success("删除成功");
        }
        /// <summary>
        /// 启用停用评价方法
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EnabledAppraiseData(string keyValue)
        {
            var meta = bll.GetAppraiseData(keyValue);
            if (meta.STATUS == "0")
                meta.STATUS = "1";
            else
                meta.STATUS = "0";
            bll.ModifyAppraiseData(keyValue, meta);
            return Success("操作成功");
        }
        
        #endregion 提交数据

        #endregion 评价方法设置


        #region 指标等级设置

        #region 视图功能

        /// <summary>
        /// 指标等级设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult PerfLevelSetting()
        {
            return View();
        }
        /// <summary>
        /// 新增/修改指标等级
        /// </summary>
        /// <param name="keyValue">评价方法编号</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditPerfLevelForm(string keyValue)
        {
            return View();
        }
        #endregion 视图功能

        #region 获取数据
        /// <summary>
        /// 获取指标等级数据列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPerfLevelListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var metas = bll.GetPerfLeveldataList(pagination, queryJson);
            var JsonData = new
            {
                rows = metas,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }
        /// <summary>
        /// 获取指标等级的数据列表，给到编辑页面
        /// </summary>
        /// <param name="keyValue">评价方法编号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPerfLevelData(string keyValue)
        {
            var meta = bll.GetPerfLevelEntity(keyValue);
            return ToJsonResult(new
            {
                XH = meta.XH,
                DJMC = meta.DJMC,
                FZSX = meta.FZSX,
                FZXX = meta.FZXX,
                STATUS = meta.STATUS,
                YEAR = meta.YEAR,
                CREATOR = meta.CREATOR
            });
        }
        #endregion 获取数据

        #region 提交数据
        /// <summary>
        /// 提交保存指标等级数据
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SavePerfLevel(BpeEA001Entity meta)
        {
            if (string.IsNullOrEmpty(meta.XH) || meta.XH.Contains("&nbsp;"))
                meta.XH = VerifyCode.GetRandomCode();
            if (string.IsNullOrEmpty(meta.CREATOR))
            {
                bll.AddPerfLevel(meta);
            }
            else
            {
                bll.ModifyPerfLevel(meta.XH, meta);
            }
            return Success("操作成功");
        }
        /// <summary>
        /// 删除指标等级
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelPerfLevel(string keyValue)
        {
            bll.RemovePerfLevel(keyValue);
            return Success("删除成功");
        }
        /// <summary>
        /// 启用停用指标等级
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EnabledPerfLevel(string keyValue)
        {
            var meta = bll.GetPerfLevelEntity(keyValue);
            if (meta.STATUS == "0")
                meta.STATUS = "1";
            else
                meta.STATUS = "0";
            bll.ModifyPerfLevel(keyValue, meta);
            return Success("操作成功");
        }
        #endregion 提交数据

        #endregion 指标等级设置


        #region 综合等级设置

        #region 视图功能
        /// <summary>
        /// 指标等级设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult SynLevelSetting()
        {
            return View();
        }
        /// <summary>
        /// 新增/修改综合等级
        /// </summary>
        /// <param name="keyValue">评价方法编号</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditSynLevelForm(string keyValue)
        {
            return View();
        }
        #endregion 视图功能

        #region 获取数据
        /// <summary>
        /// 获取综合等级设置
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetSynLevelListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var metas = bll.GetSynLeveldataList(pagination, queryJson);
            var JsonData = new
            {
                rows = metas,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }
        /// <summary>
        /// 获取综合的数据列表，给到编辑页面
        /// </summary>
        /// <param name="keyValue">评价方法编号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSynLevelData(string keyValue)
        {
            var meta = bll.GetSynLevelEntity(keyValue);
            return ToJsonResult(new
            {
                XH = meta.XH,
                DJMC = meta.DJMC,
                FZSX = meta.FZSX,
                FZXX = meta.FZXX,
                STATUS = meta.STATUS,
                YEAR = meta.YEAR,
                CREATOR = meta.CREATOR
            });
        }
        #endregion 获取数据

        #region 提交数据
        /// <summary>
        /// 提交保存综合等级数据
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveSynLevel(BpeEA002Entity meta)
        {
            if (string.IsNullOrEmpty(meta.XH) || meta.XH.Contains("&nbsp;"))
                meta.XH = VerifyCode.GetRandomCode();
            if (string.IsNullOrEmpty(meta.CREATOR))
            {
                bll.AddSynLevel(meta);
            }
            else
            {
                bll.ModifySynLevel(meta.XH, meta);
            }
            return Success("操作成功");
        }
        /// <summary>
        /// 删除综合等级数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelSynLevel(string keyValue)
        {
            bll.RemoveSynLevel(keyValue);
            return Success("删除成功");
        }
        /// <summary>
        /// 启用停用综合等级
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EnabledSynLevel(string keyValue)
        {
            var meta = bll.GetSynLevelEntity(keyValue);
            if (meta.STATUS == "0")
                meta.STATUS = "1";
            else
                meta.STATUS = "0";
            bll.ModifySynLevel(keyValue, meta);
            return Success("操作成功");
        }
        #endregion 提交数据

        #endregion 综合等级设置

    }
}

