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
    public class BusinessSystemController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult SystemManage()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult EditionManage()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult SystemParameterManage()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult SystemConfigureManage()
        {
            return View();
        }

    }
}
