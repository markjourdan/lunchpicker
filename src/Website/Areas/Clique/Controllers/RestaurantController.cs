using System;
using System.Web.Mvc;
using Dino;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;

namespace LunchPicker.Web.Areas.Clique.Controllers
{
    public class RestaurantController : Controller
    {
        public ILunchRepository LunchRepository { get; set; }
        public ISession _Session { get; set; }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult GetRestaurants(DataSourceRequest request)
        {
            return Json(LunchRepository.GetResturants().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateRestaurant(DataSourceRequest request, Restaurant restaurant)
        {
            if (restaurant != null && ModelState.IsValid)
            {
                var target = LunchRepository.GetResturant(restaurant.RestaurantId);

                if (target != null)
                {
                    target.Name = restaurant.Name;
                    target.Phone = restaurant.Phone;
                    target.Address1 = restaurant.Address1;
                    target.Address2 = restaurant.Address2;
                    target.City = restaurant.City;
                    target.StateId = restaurant.StateId;
                    target.Zip = restaurant.Zip;
                    target.Update(User);
                    
                    _Session.Commit();
                }
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpDelete]
        public ActionResult DeleteRestaurant(DataSourceRequest request, Restaurant restaurant)
        {
            if (restaurant != null)
            {
                var restaurantToDelete = LunchRepository.GetResturant(restaurant.RestaurantId);
                LunchRepository.DeleteRestaurant(restaurantToDelete);

                _Session.Commit();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpPut]
        public ActionResult AddRestaurant(DataSourceRequest request, Restaurant restaurant)
        {
            restaurant.LastUpdatedDateUtc = restaurant.CreatedDateUtc = DateTime.UtcNow;
            restaurant.CreatedBy = User.Identity.Name;

            if (ModelState.IsValid)
            {
                LunchRepository.Add(restaurant);
                _Session.Commit();
            }

            return Json(new[] { restaurant }.ToDataSourceResult(request, ModelState));
        }
    }
}
