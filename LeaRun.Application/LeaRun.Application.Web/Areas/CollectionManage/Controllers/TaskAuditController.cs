using LeaRun.Application.Busines.CollectionManage;
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
    /// 采集管理-审核管理
    /// </summary>
    public class TaskAuditController : MvcControllerBase
    {
        MyTaskAuditBLL bll;
        /// <summary>
        /// 
        /// </summary>
        public TaskAuditController()
        {
            bll = new MyTaskAuditBLL();
        }

        /// <summary>
        /// 我的审核任务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 审核确认
        /// </summary>
        /// <param name="keyValues"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public ActionResult AuditForm(string keyValues, string keyNames)
        {
            ViewData["keyNames"] = keyNames;
            return View();
        }

        /// <summary>
        /// 获取我的审核任务列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTaskListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var tasks = bll.GetMyTaskAudit(pagination, queryJson);
            var JsonData = new
            {
                rows = tasks,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="keyValues"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Audit(string keyValues, string status)
        {
            foreach (var item in keyValues.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                bll.Audit(item, status);
            }
            return Success("操作成功");
        }

    }
}
