using System.Web.Mvc;

namespace LunchPicker.Web.Areas.Clique
{
    public class CliqueAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Clique";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Clique_default",
                "Clique/{cliqueId}/{controller}/{action}/{id}",
                new { controller = "Clique", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
