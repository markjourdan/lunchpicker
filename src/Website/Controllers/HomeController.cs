using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LunchPicker.Domain.DataTransferObject;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Web.Areas.Clique.Models.Restaurant;

namespace LunchPicker.Web.Controllers
{
    public class HomeController : Controller
    {
        public IRestaurantRepository RestaurantRepository { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RestaurantRanking()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRestaurantPick()
        {
            var resturants = RestaurantRepository.GetRestaurants();

            var rand = new Random();

            var restaurants = resturants as List<Restaurant> ?? resturants.ToList();
            var randomNumber = rand.Next(0, restaurants.Count());

            return Json(restaurants.Skip(randomNumber).Select(a => new RestaurantModel
                                                                   {
                                                                       RestaurantId = a.RestaurantId,
                                                                       StateId = a.StateId,
                                                                       Name = a.Name,
                                                                       Address2 = a.Address2,
                                                                       City = a.City,
                                                                       Phone = a.Phone,
                                                                       State = new StateDto
                                                                               {
                                                                                   Abbreviation = a.State.Abbreviation,
                                                                                   FullName = a.State.FullName,
                                                                                   StateId = a.State.StateId
                                                                               },
                                                                       Address1 = a.Address1,
                                                                       Zip = a.Zip
                                                                   }).First(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult GetRestaurantRanking(DataSourceRequest request)
        {
            var restaurants = Mapper.Map<IEnumerable<Restaurant>, IEnumerable<RestaurantListingDto>>(RestaurantRepository.GetRestaurants()).OrderByDescending(r => r.Rating);

            return Json(restaurants.ToDataSourceResult(request));
        }
    }
}
