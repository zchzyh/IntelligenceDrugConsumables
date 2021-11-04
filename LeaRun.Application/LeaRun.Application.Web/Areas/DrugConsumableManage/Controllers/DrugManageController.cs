using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.DrugConsumableManage.Controllers
{
    public class DrugManageController : MvcControllerBase
    {
        //
        // GET: /DrugConsumableManage/DrugManage/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DrugCallInfo()
        {
            return View();
        }

        public ActionResult DrugCodeMapping()
        {
            return View();
        }

        public ActionResult DrugHospitalInfo()
        {
            return View();
        }
    }
}
