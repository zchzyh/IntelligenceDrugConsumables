using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.DrugConsumableManage
{
    public class DrugConsumableManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DrugConsumableManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DrugConsumableManage_default",
                "DrugConsumableManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
