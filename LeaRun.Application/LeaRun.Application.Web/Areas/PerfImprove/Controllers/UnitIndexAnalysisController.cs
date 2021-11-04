using LeaRun.Application.Busines.PerfImprove;
using LeaRun.Application.Code;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfImprove.Controllers
{
    /// <summary>
    /// 绩效改进-单位指标分析
    /// </summary>
    public class UnitIndexAnalysisController : MvcControllerBase
    {
        /// <summary>
        /// 单位指标分析
        /// </summary>
        UnitIndexAnalysisBLL bll;

        /// <summary>
        /// 控制器构造函数
        /// </summary>
        public UnitIndexAnalysisController()
        {
            bll = new UnitIndexAnalysisBLL();
        }

        #region 目标比较法分析

        /// <summary>
        /// 目标比较法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult TargetComparison()
        {
            return View();
        }

        #region 视图功能

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取年度下拉框
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetYearsJson(bool forSearch = false)
        {
            var years = bll.GetYears();
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "全部");
            foreach (var item in years)
            {
                items.Add(item.BMKey, item.MCValue);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取全部科室下拉框
        /// </summary>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDepartsJson(string jxbm)
        {
            var departs = bll.GetDepartmentBms(jxbm).ToList();
            var items = new Dictionary<string, string>();
            foreach (var item in departs)
            {
                items.Add(item.DEPTID, item.DEPTNAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 目标比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTargetListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var targetList = bll.GetTargetComparison(pagination, queryJson);
            var JsonData = new
            {
                rows = targetList,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        #endregion

        #endregion

        #region 纵向比较法分析

        /// <summary>
        /// 纵向比较法
        /// </summary>
        /// <returns></returns>
        public ActionResult VerticalComparison()
        {
            return View();
        }

        #region 视图功能

        #endregion

        #region 获取数据

        /// <summary>
        /// 纵向比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetVerticalListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var verticalList = bll.GetVerticalComparison(pagination, queryJson);
            var JsonData = new
            {
                rows = verticalList,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        #endregion

        #endregion

        #region 横向比较法分析

        /// <summary>
        /// 横向比较法
        /// </summary>
        /// <returns></returns>
        public ActionResult HorizontalComparison()
        {
            return View();
        }

        #region 视图功能

        #endregion

        #region 获取数据

        /// <summary>
        /// 横向比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetHorizontalListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var horizontalList = bll.GetHorizontalComparison(pagination, queryJson);
            var JsonData = new
            {
                rows = horizontalList,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        #endregion

        #endregion

    }
}
