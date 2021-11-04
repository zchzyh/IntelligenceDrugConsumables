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

        [HttpGet]
        public ActionResult GetDrugType()
        {
            var items = new Dictionary<string, string>();

            items.Add("1001", "国家药品字典");
            items.Add("1002", "广东省药品目录");

            return ToJsonResult(SetComboBoxValue(items));
        }
    }
}
