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

namespace LunchPicker.Web.Controllers
{
    public class HomeController : Controller
    {
        public ILunchRepository LunchRepository { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RestaurantRanking()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetRestaurantPick()
        {
            var resturants = LunchRepository.GetResturants();

            var rand = new Random();

            var restaurants = resturants as List<Restaurant> ?? resturants.ToList();
            var randomNumber = rand.Next(0, restaurants.Count());

            return Json(restaurants.Skip(randomNumber).First(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult GetResturantRanking(DataSourceRequest request)
        {
            var restaurants = Mapper.Map<IEnumerable<Restaurant>, IEnumerable<RestaurantListingDto>>(LunchRepository.GetResturants()).OrderByDescending(r => r.Rating);

            return Json(restaurants.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Restaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }
    }
}
