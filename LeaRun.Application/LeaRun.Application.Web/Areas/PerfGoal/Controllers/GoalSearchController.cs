using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Busines.PerfGoal;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Code;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfGoal.Controllers
{
    /// <summary>
    /// 绩效目标-目标值检索
    /// </summary>
    public class GoalSearchController : MvcControllerBase
    {
        PerfGoalBLL bll;
        YearSettingBLL yearBll;
        /// <summary>
        /// 
        /// </summary>
        public GoalSearchController()
        {
            bll = new PerfGoalBLL();
            yearBll = new YearSettingBLL();
        }

        #region 视图功能
        /// <summary>
        /// 单位目标值检索
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 目标值列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetGoalListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var lst = bll.GetQuantitativeGoalList(pagination, queryJson);
            var JsonData = new
            {
                rows = lst,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetDeptsJson()
        {
            var items = new Dictionary<string, string>();
            items.Add("", "不限部门");
            var lst = yearBll.GetDepartmentBms("");
            foreach (var item in lst)
            {
                if (!items.ContainsKey(item.DEPTID))
                    items.Add(item.DEPTID, item.DEPTNAME);
            }
            return ToJsonResult(SetComboBoxValue(items));
        }

        #endregion

    }
}
