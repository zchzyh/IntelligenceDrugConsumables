using LeaRun.Application.Code;
using LeaRun.Util;
using LeaRun.Util.Log;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LeaRun.Application.Web
{
    /// <summary>
    /// 版 本 6.1
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2015.11.9 10:45
    /// 描 述：控制器基类
    /// </summary>
    [HandlerLogin(LoginMode.Enforce)]
    public abstract class MvcControllerBase : Controller
    {
        private Log _logger;
        /// <summary>
        /// 日志操作
        /// </summary>
        public Log Logger
        {
            get { return _logger ?? (_logger = LogFactory.GetLogger(this.GetType().ToString())); }
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult ToJsonResult(object data)
        {
            return Content(data.ToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message)
        {
            return Content(new AjaxResult { type = ResultType.success, message = message }.ToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message, object data)
        {
            return Content(new AjaxResult { type = ResultType.success, message = message, resultdata = data }.ToJson());
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message)
        {
            return Content(new AjaxResult { type = ResultType.error, message = message }.ToJson());
        }

        /// <summary>
        /// 设置下拉框内容
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        protected List<object> SetComboBoxValue(Dictionary<string, string> items)
        {
            List<object> l = new List<object>();
            foreach (var item in items)
            {
                l.Add(new
                {
                    ItemValue = item.Key,
                    ItemText = item.Value
                });
            }
            return l;
        }

        /// <summary>
        /// 获取默认的分页参数
        /// </summary>
        /// <param name="sidx">排序字段</param>
        /// <returns></returns>
        protected Pagination GetDefaultPagination(string sidx)
        {
            return new Pagination
            {
                page = 1,
                rows = 10000,
                sidx = sidx,
                sord = "desc"
            };
        }
    }
}
