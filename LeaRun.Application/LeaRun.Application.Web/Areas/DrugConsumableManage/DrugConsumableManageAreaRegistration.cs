using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.DrugConsumableManage
{
    /// <summary>
    /// 
    /// </summary>
    public class DrugConsumableManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DrugConsumableManage";
            }
        }

        //public override void RegisterArea(AreaRegistrationContext context)
        //{
        //    context.MapRoute(
        //        "DrugConsumableManage_default",
        //        "DrugConsumableManage/{controller}/{action}/{id}",
        //        new { action = "Index", id = UrlParameter.Optional }
        //    );
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "LeaRun.Application.Web.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}
