using LeaRun.Application.Busines.CollectionManage;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Code;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.CollectionManage.Controllers
{
    /// <summary>
    /// 采集管理-数据修正法
    /// </summary>
    public class DataCorrectController : MvcControllerBase
    {
        /// <summary>
        /// 数据修正法
        /// </summary>
        DataCorrectBLL bll;

        /// <summary>
        /// 字典
        /// </summary>
        DictionaryBLL dicBll;

        /// <summary>
        /// 控制器构造函数
        /// </summary>
        public DataCorrectController()
        {
            bll = new DataCorrectBLL();
            dicBll = new DictionaryBLL();
        }

        #region 系数修正法

        /// <summary>
        /// 系数修正法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult CoefficientCorrect()
        {
            return View();
        }

        #region 视图功能

        /// <summary>
        /// 保存数据修正
        /// </summary>
        /// <param name="type">数据修正类型</param>
        /// <param name="dataCorrectList">数据修正列表</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveDataCorrect(string type, string dataCorrectList)
        {
            bll.UpateDataCorrect(type, dataCorrectList);
            return Success("操作成功。");
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取年度下拉框
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetYearsJson(bool forSearch = true)
        {
            var years = bll.GetYears();
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "全部年度");
            foreach (var item in years)
            {
                items.Add(item.BMKey, item.MCValue);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取月度下拉框
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMonthsJson(bool forSearch = true)
        {
            var months = dicBll.GetStandardCodes(Config.GetValue("MonthType")).OrderBy(t => t.IX);
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "全部月份");
            foreach (var item in months)
            {
                items.Add(item.CODE, item.NAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取所属类别下拉框
        /// </summary>
        /// <param name="forSearch">是否用于查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTypesJson(bool forSearch = true)
        {
            var types = bll.GetTypes();
            var items = new Dictionary<string, string>();
            if (forSearch)
                items.Add("", "全部所属类别");
            foreach (var item in types)
            {
                items.Add(item.BMKey, item.MCValue);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 系数修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCoefficientListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var coefficientList = bll.GetCoefficientCorrect(pagination, queryJson);
            var JsonData = new
            {
                rows = coefficientList,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }


        #endregion


        #endregion

        #region 归零修正法

        /// <summary>
        /// 归零修正法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ZeroingCorrect()
        {
            return View();
        }

        #region 视图功能

        #endregion

        #region 获取数据

        /// <summary>
        /// 归零修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetZeroingListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var zeroingList = bll.GetZeroingCorrect(pagination, queryJson);
            var JsonData = new
            {
                rows = zeroingList,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        #endregion

        #endregion

        #region 补录修正法

        /// <summary>
        /// 补录修正法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult SupplementCorrect()
        {
            return View();
        }

        #region 视图功能

        #endregion

        #region 获取数据

        /// <summary>
        /// 补录修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSupplementListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var supplementList = bll.GetSupplementCorrect(pagination, queryJson);
            var JsonData = new
            {
                rows = supplementList,
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
