using System.Web.Mvc;

namespace LunchPicker.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RestaurantRanking()
        {
            throw new System.NotImplementedException();
        }
    }
}
