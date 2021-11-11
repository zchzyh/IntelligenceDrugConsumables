using LeaRun.Application.Busines.BusinessManage;
using LeaRun.Application.Busines.SettingManage;
using LeaRun.Application.Code;
using LeaRun.Util;
using LeaRun.Util.WebControl;
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
    public class BusinessSystemController : MvcControllerBase
    {
        BusinessSystemBLL businesssystembll;
        private readonly DictionaryBLL dictionaryBLL = new DictionaryBLL();

        /// <summary>
        /// 
        /// </summary>
        public BusinessSystemController()
        {
            businesssystembll = new BusinessSystemBLL();
        }
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
        public ActionResult SystemParameterSettings()
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSystemList(Pagination pagination, string queryJson)
        {
            var druglist = businesssystembll.GetSystemList(pagination, queryJson);

            return ToJsonResult(druglist);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSystemEditionInfo(Pagination pagination, string queryJson)
        {
            var systemeditionlist = businesssystembll.GetSystemEditionInfo(pagination, queryJson);
            return ToJsonResult(systemeditionlist);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public ActionResult GetSystemParameters(Pagination pagination, string queryJson)
        {
            var systemparameterlist = businesssystembll.GetSystemParameters(pagination,queryJson);
            return ToJsonResult(systemparameterlist);
        }

        /// <summary>
        /// 获取或查找编码
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        //[HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult GetCodeList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = dictionaryBLL.GetStandardCodes(pagination, queryJson);
            var JsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Content(JsonData.ToJson());
        }
    }
}
