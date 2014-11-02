using System.Linq;
using System.Web.Mvc;
using Dino;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LunchPicker.Domain;
using LunchPicker.Domain.DataTransferObject;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Web.Areas.Clique.Models.Clique;
using LunchPicker.Web.Areas.Clique.Models.Restaurant;

namespace LunchPicker.Web.Areas.Clique.Controllers
{
    public class RestaurantController : Controller
    {
        public ILunchRepository LunchRepository { get; set; }
        public IClock Clock { get; set; }
        public ISession _Session { get; set; }

        public ActionResult About(long id)
        {
            var model = LunchRepository.GetRestaurant(id);
            return View(model);
        }

        public ActionResult Manage()
        {
            var model = new ManageRestaurant {States = LunchRepository.GetStates().Select(s => new StateDto
                                                                                               {
                                                                                                   Abbreviation = s.Abbreviation,
                                                                                                   FullName = s.FullName,
                                                                                                   StateId = s.StateId
                                                                                               })};
            return View(model);
        }

        [HttpGet]
        public ActionResult GetRestaurants(DataSourceRequest request)
        {
            return Json(LunchRepository.GetRestaurants().Cast<Restaurant>()
                .Select(r => new RestaurantModel
                             {
                                 RestaurantId = r.RestaurantId,
                                 Address1 = r.Address1,
                                 Address2 = r.Address2,
                                 City = r.City,
                                 Name = r.Name,
                                 Phone = r.Phone,
                                 State = new StateDto
                                         {
                                             Abbreviation = r.State.Abbreviation,
                                             FullName = r.State.FullName,
                                             StateId = r.State.StateId
                                         },
                                 StateId = r.StateId,
                                 Zip = r.Zip
                             }).ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateRestaurant(DataSourceRequest request, RestaurantModel restaurant)
        {
            if (restaurant != null && ModelState.IsValid)
            {
                var target = LunchRepository.GetRestaurant(restaurant.RestaurantId);

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
        public ActionResult DeleteRestaurant(DataSourceRequest request, RestaurantModel restaurant)
        {
            if (restaurant != null)
            {
                var restaurantToDelete = LunchRepository.GetRestaurant(restaurant.RestaurantId);
                LunchRepository.DeleteRestaurant(restaurantToDelete);

                _Session.Commit();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpPut]
        public ActionResult AddRestaurant(DataSourceRequest request, Restaurant restaurant)
        {
            restaurant.LastUpdatedDateUtc = restaurant.CreatedDateUtc = Clock.UtcNow;
            restaurant.CreatedBy = restaurant.LastUpdatedBy = User.Identity.Name;

            if (ModelState.IsValid)
            {
                if (restaurant.StateId.HasValue)
                    restaurant.State = LunchRepository.GetState(restaurant.StateId.GetValueOrDefault());

                LunchRepository.Add(restaurant);
                _Session.Commit();
            }

            return Json(new[] { restaurant }.ToDataSourceResult(request, ModelState));
        }

        [HttpGet]
        public ActionResult GetStates()
        {
            var states = LunchRepository.GetStates().Select(s => new StateDto
                                                                 {
                                                                     Abbreviation = s.Abbreviation,
                                                                     FullName = s.FullName,
                                                                     StateId = s.StateId
                                                                 });

            return new JsonResult {Data = states, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}
