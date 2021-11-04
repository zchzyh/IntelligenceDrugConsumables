using LeaRun.Application.Busines.DataAnalysis;
using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Code;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfProcess.Controllers
{
    /// <summary>
    /// 元数据分析——单位
    /// </summary>
    public class MetaAnalysisController : MvcControllerBase
    {
        // BLL
        readonly DataAnalysisBLL bll;
        readonly YearSettingBLL yearbll;
        readonly KpiSettingBLL kpibll;

        /// <summary>
        /// 
        /// </summary>
        public MetaAnalysisController()
        {
            bll = new DataAnalysisBLL();
            yearbll = new YearSettingBLL();
            kpibll = new KpiSettingBLL();
        }

        #region 视图功能

        /// <summary>
        /// 按单位月度分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult UnitMonthly()
        {
            return View();
        }

        /// <summary>
        /// 按元数据月度分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult MetaMonthly()
        {
            return View();
        }

        /// <summary>
        /// 按单位同比分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult UnitYearly()
        {
            return View();
        }

        /// <summary>
        /// 按元数据同比分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult MetaYearly()
        {
            return View();
        }

        /// <summary>
        /// 按单位环比分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult UnitChain()
        {
            return View();
        }

        /// <summary>
        /// 按元数据环比分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult MetaChain()
        {
            return View();
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取全部科室信息
        /// </summary>
        /// <param name="jxbm"></param>
        /// <param name="all"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDepartmentsJson(string jxbm, bool all = true)
        {
            var departmentList = yearbll.GetDepartmentBms(jxbm).ToList();
            var items = new Dictionary<string, string>();
            if (all)
                items.Add("", "全部科室");
            foreach (var item in departmentList)
            {
                items.Add(item.DEPTID, item.DEPTNAME);
            }

            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取全部元数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <param name="all"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMetaDataJson(Pagination pagination, string queryJson, bool all = true)
        {
            var metas = kpibll.GetMetadataList(pagination, queryJson);
            var items = new Dictionary<string, string>();
            if (all)
                items.Add("", "不限选择");
            foreach (var item in metas)
            {
                if (!items.ContainsKey(item.METCODE))
                {
                    items.Add(item.METCODE, item.METNAME);
                }
            }

            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 按单位获取月度分析数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUnitMonthAnalysisListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetMonthlyList(pagination, queryJson);
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
        /// 按元数据获取月度分析数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMetaMonthAnalysisListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetMonthlyList(pagination, queryJson);
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
        /// 按单位获取同比分析数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUnitYearAnalysisListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetYoyList(pagination, queryJson);
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
        /// 按元数据获取同比分析数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMetaYearAnalysisListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetYoyList(pagination, queryJson);
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
        /// 按单位获取环比分析数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUnitChainAnalysisListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetMomList(pagination, queryJson);
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
        /// 按元数据获取环比分析数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMetaChainAnalysisListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetMomList(pagination, queryJson);
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
