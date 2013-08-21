using System.Web.Mvc;
using LunchPicker.Web.Framework;

namespace LunchPicker.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}