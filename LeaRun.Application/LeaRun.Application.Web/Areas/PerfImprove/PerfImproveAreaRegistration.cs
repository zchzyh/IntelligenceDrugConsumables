using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfImprove
{
    /// <summary>
    /// 绩效改进区域
    /// </summary>
    public class PerfImproveAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// 区域名
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "PerfImprove";
            }
        }

        /// <summary>
        /// 注册区域
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                this.AreaName + "_default",
                this.AreaName + "/{controller}/{action}/{id}",
                new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
               new string[] { "LeaRun.Application.Web.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}
