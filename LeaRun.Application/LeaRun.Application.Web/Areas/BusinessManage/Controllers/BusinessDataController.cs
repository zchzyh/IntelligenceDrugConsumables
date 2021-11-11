using LeaRun.Application.Busines.BusinessManage;
using LeaRun.Util.WebControl;
using LeaRun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.BusinessManage
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessDataController : MvcControllerBase
    {
        BusinessDataBLL businessDataBLL;
        /// <summary>
        /// 
        /// </summary>
        public BusinessDataController()
        {
            businessDataBLL = new BusinessDataBLL();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult PatientData()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult PacsData()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult LisData()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult SensingData()
        {
            return View();
        }
        /// <summary>
        /// 处方数据
        /// </summary>
        /// <returns></returns>
        public ActionResult PrescriptionData()
        {
            return View();
        }
        /// <summary>
        /// 医嘱数据
        /// </summary>
        /// <returns></returns>
        public ActionResult DoctorAdviceData()
        {
            return View();
        }
        /// <summary>
        /// 手术数据
        /// </summary>
        /// <returns></returns>
        public ActionResult OperationData()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPantientInfoList(Pagination pagination, string queryJson)
        {
            var pantientinfolist = businessDataBLL.GetPantientInfoList(pagination, queryJson);
            return ToJsonResult(pantientinfolist);
        }
    }
}
