using System.Web.Mvc;

namespace LunchPicker.Web.Areas.CrunchAdmin
{
    public class CrunchAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CrunchAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CrunchAdmin_default",
                "CrunchAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
