using LeaRun.Application.Busines.PerfConfig;
using LeaRun.Application.Busines.PerfReport;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfReport;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LeaRun.Application.Web.Areas.PerfReport.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DepartmentReportController : MvcControllerBase
    {
        readonly YearSettingBLL yearbll;
        readonly DeptPerfReportBLL bll;

        /// <summary>
        /// 
        /// </summary>
        public DepartmentReportController()
        {
            yearbll = new YearSettingBLL();
            bll = new DeptPerfReportBLL();
        }

        #region 视图功能

        /// <summary>
        /// 定性
        /// </summary>
        /// <returns></returns>
        public ActionResult Qualitation()
        {
            return View();
        }

        /// <summary>
        /// 定量
        /// </summary>
        /// <returns></returns>
        public ActionResult Quantitation()
        {
            return View();
        }

        /// <summary>
        /// 综合评价
        /// </summary>
        /// <returns></returns>
        public ActionResult ComprehensiveEvaluation()
        {
            return View();
        }

        /// <summary>
        /// 下一年改进
        /// </summary>
        /// <returns></returns>
        public ActionResult NextYear()
        {
            return View();
        }

        /// <summary>
        /// 最终评定报告
        /// </summary>
        /// <returns></returns>
        public ActionResult FinalAssessmentRep()
        {
            return View();
        }


        public ActionResult SchemeWeight()
        {
            return View();
        }

        public ActionResult WeightView(string year,string officeNo,string JGFABH,string jxbm,string officeName,string JGFAMC)
        {
            ViewBag.year = year;
            ViewBag.officeNo = officeNo;
            ViewBag.JGFABH = JGFABH;
            ViewBag.jxbm = jxbm;
            ViewBag.officeName = officeName;
            ViewBag.JGFAMC = JGFAMC;

            return View();
        }

        #endregion

        #region 读取数据

        /// <summary>
        /// 获取全部科室信息
        /// </summary>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDepartmentsJson(string jxbm,bool includeAll=false)
        {
            var departmentList = yearbll.GetDepartmentBms(jxbm).ToList();
            var items = new Dictionary<string, string>();
            if(includeAll)
              items.Add("","所有科室");
            foreach (var item in departmentList)
            {
                items.Add(item.DEPTID, item.DEPTNAME);
            }

            return ToJsonResult(SetComboBoxValue(items));
        }

        /// <summary>
        /// 获取定量等级报告
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetQuantitativeReportList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetQuantitativeReportList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取定量等级报告
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetQualitativeReportList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetQualitativeReportList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取权重等级报告
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetWeightReportList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetSchemeWeighList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = 1,//pagination.total,
                page = pagination.page,
                records = data.Count(),// pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }
        /// <summary>
        /// 获取综合评价等级报告
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetComprehensiveReportList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetComprehensiveReportList(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 获取下一年改进报告
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns> 
        [HttpGet]
        public ActionResult GetNextYearReportList(string queryJson)
        {
            StringBuilder sb = new StringBuilder();
            var data = bll.GetNextYearReportList(queryJson).OrderByDescending(r => r.KPIDJ).ThenByDescending(r => r.KPIMC);
            foreach (var item in data)
            {
                //if (!item.KPIDJ.StartsWith("A", StringComparison.OrdinalIgnoreCase) && !item.KPIDJ.StartsWith("B", StringComparison.OrdinalIgnoreCase))
                //{
                //    sb.Append("指标：" + item.KPIMC + "，" + "等级结果：" + item.KPIDJ + ";");
                //    sb.Append("\r\n");
                //}
                if (string.Compare(item.KPIDJ.Substring(0, 1).ToUpper(), "B") > 0)
                {
                    sb.Append("指标：" + item.KPIMC + "，" + "等级结果：" + item.KPIDJ + ";");
                    sb.Append("\r\n\r\n");
                }
            }
            return Json(sb.ToString(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取最终评定报告列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="year_code">年度编号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetFinalAssessmentRep(Pagination pagination, string year_code)
        {
            var watch = CommonHelper.TimerStart();
            var data = bll.GetFinalAssessmentRep(pagination, year_code);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

 
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveComprehensiveEvaluation( string list)
        {
            var ra003List=JsonConvert.DeserializeObject<List<BpeRA003Entity>>(list);
            bll.UpdateSFYPFJ(ra003List);
            return Success("操作成功");
        }
    }
}
