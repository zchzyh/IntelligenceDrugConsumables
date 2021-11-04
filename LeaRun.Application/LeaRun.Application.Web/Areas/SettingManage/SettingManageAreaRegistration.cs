using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.SettingManage
{
    public class SettingManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SettingManage";
            }
        }

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