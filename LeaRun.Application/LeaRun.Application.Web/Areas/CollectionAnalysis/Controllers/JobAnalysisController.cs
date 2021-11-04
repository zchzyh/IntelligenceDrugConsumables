using LeaRun.Application.Busines.CollectionAnalysis;
using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Code;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.CollectionAnalysis.Controllers
{
    /// <summary>
    /// 采集工作分析
    /// </summary>
    public class JobAnalysisController : MvcControllerBase
    {
        // BLL
        readonly CollectionWorkAnalysisBLL bll;

        /// <summary>
        /// 
        /// </summary>
        public JobAnalysisController()
        {
            bll = new CollectionWorkAnalysisBLL();
        }
        #region 视图功能

        /// <summary>
        /// 采集任务督查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult CollectionSupervision()
        {
            return View();
        }

        /// <summary>
        /// 审核任务督查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ExamineSupervision()
        {
            return View();
        }

        /// <summary>
        /// 采集任务预警
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Warning()
        {
            return View();
        }

        /// <summary>
        /// 年度任务分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult YearlyAnalysis()
        {
            return View();
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取采集任务督查列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCollectionTaskInspectList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetCollectionTaskInspectList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取审核任务督查列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAuditTaskInspectList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetAuditTaskInspectList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取采集任务预警列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCollectionTaskWarningList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetCollectionTaskWarningList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取年度任务分析列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetYearTaskAnalysisList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetYearTaskAnalysisList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        #endregion

    }
}
