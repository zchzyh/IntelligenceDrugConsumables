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
    /// 采集数据分析
    /// </summary>
    public class DataAnalysisController : MvcControllerBase
    {
        // BLL
        readonly CollectionDataAnalysisBLL bll;

        /// <summary>
        /// 
        /// </summary>
        public DataAnalysisController()
        {
            bll = new CollectionDataAnalysisBLL();
        }
        #region 视图功能

        /// <summary>
        /// 数据项月度分析
        /// </summary>  
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Month()
        {
            return View();
        }

        /// <summary>
        /// 数据项年度分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Year()
        {
            return View();
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取数据项月度分析列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetStandardDataMonthAnalysisList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetStandardDataMonthAnalysisList(pagination, queryJson);
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
        /// 获取数据项年度分析列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCollectionTaskInspectList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetStandardDataYearAnalysisList(pagination, queryJson);
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
