using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.PerfScheme
{
    public class PerfSchemeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PerfScheme";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PerfScheme_default",
                "PerfScheme/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
