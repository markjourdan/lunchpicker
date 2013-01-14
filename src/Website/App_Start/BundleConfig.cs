using System.Web.Optimization;

namespace LunchPicker.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.*"));
            
            bundles.Add(new ScriptBundle("~/Scripts/jquery-rumble").Include(
                "~/Scripts/jrumble.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css"));
        }
    }
}