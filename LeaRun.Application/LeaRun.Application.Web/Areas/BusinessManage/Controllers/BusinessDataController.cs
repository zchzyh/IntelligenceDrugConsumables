using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.BusinessManage
{
    public class BusinessDataController : Controller
    {
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
    }
}
