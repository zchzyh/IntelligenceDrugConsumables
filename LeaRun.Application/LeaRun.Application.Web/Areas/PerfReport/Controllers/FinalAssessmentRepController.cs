using LeaRun.Application.Busines.PerfReport;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LeaRun.Application.Web.Areas.PerfReport.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class FinalAssessmentRepController : MvcControllerBase
    {
        DeptPerfReportBLL bll ;

        /// <summary>
        /// 
        /// </summary>
        public FinalAssessmentRepController()
        {
            bll = new DeptPerfReportBLL();
        }

        // GET: /PerfReport/FinalAssessmentRep/

        #region 视图功能
        /// <summary>
        /// /新增/修改最终评定报告
        /// </summary>
        /// <param name="year_code">年度</param>
        /// <param name="serial_num">序号</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditFinalAssessmentRep(string year_code, string serial_num)
        {
            return View();
        }


        #endregion

        /// <summary>
        /// 删除综合评价报告
        /// </summary>
        /// <param name="year_code">年度</param>
        /// <param name="serial_num">序号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult DelFinalAssessmentRep(string year_code, string serial_num)
        {
            bll.RemoveFinalAssessmentForm(year_code, serial_num);
            return Success("删除成功");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial_num"></param>
        /// <returns></returns>
        public ActionResult GetFinalAssessmentRep( string serial_num)
        {
            var quan = bll.GetFinalAssessmentRepEntity(serial_num);
            return ToJsonResult(quan);
        }


/// <summary>
/// 保存最终评定报告
/// </summary>
/// <param name="meta"></param>
/// <param name="serial_num"></param>
/// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveMeta(BpeRA005Entity meta,string serial_num)
        {
            try
            {
                if (string.IsNullOrEmpty(serial_num) || serial_num.Contains("&nbsp;"))
                {
                    meta.serial_num = VerifyCode.GetRandomCode();
                    bll.CreateFinalAssessmentForm(meta);
                }
                else
                    bll.ModifyFinalAssessmentForm(null, meta);
                return Success("操作成功");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
