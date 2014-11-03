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
using LunchPicker.Infrastructure.Repositories;
using LunchPicker.Web.Models.Home;
using RestaurantModel = LunchPicker.Web.Areas.Clique.Models.Restaurant.RestaurantModel;

namespace LunchPicker.Web.Controllers
{
    public class HomeController : Controller
    {
        public IRestaurantRepository RestaurantRepository { get; set; }
        public ICliqueRepository CliqueRepository {get; set; }

        public ActionResult Index()
        {
            var model = new CrunchModel
            {
                Cliques = CliqueRepository.GetCliquesByUser(User.Identity.Name)
                    .Select(s => new CliqueDto
                    {
                        CliqueId = s.CliqueId,
                        FriendlyKey = s.FriendlyKey,
                        IsActive = s.IsActive,
                        Name = s.Name
                    }).ToList()
            };
            return View(model);
        }

        public ActionResult RestaurantRanking()
        {
            var model = new RestaurantRankingModel
                        {
                            Cliques = CliqueRepository.GetCliquesByUser(User.Identity.Name)
                                .Select(s => new CliqueDto
                                             {
                                                 CliqueId = s.CliqueId,
                                                 FriendlyKey = s.FriendlyKey,
                                                 IsActive = s.IsActive,
                                                 Name = s.Name
                                             }).ToList()
                        };
            return View(model);
        }

        [HttpGet]
        public ActionResult GetRestaurantPick(int cliqueId)
        {
            var resturants = RestaurantRepository.GetRestaurantsByClique(cliqueId);

            var rand = new Random();

            var restaurants = resturants as List<Restaurant> ?? resturants.ToList();
            if (restaurants.Any())
            {
                var randomNumber = rand.Next(0, restaurants.Count());

                return Json(restaurants.Skip(randomNumber).Select(a => new RestaurantModel
                                                                       {
                                                                           RestaurantId = a.RestaurantId,
                                                                           CliqueId = a.CliqueId,
                                                                           StateId = a.StateId,
                                                                           Name = a.Name,
                                                                           Address2 = a.Address2,
                                                                           City = a.City,
                                                                           Phone = a.Phone,
                                                                           State = new StateDto
                                                                                   {
                                                                                       Abbreviation =
                                                                                           a.State.Abbreviation,
                                                                                       FullName = a.State.FullName,
                                                                                       StateId = a.State.StateId
                                                                                   },
                                                                           Address1 = a.Address1,
                                                                           Zip = a.Zip
                                                                       }).First(), JsonRequestBehavior.AllowGet);
            }
            return Json(new RestaurantModel(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult GetRestaurantRanking(DataSourceRequest request, int cliqueId)
        {
            var restaurants = Mapper.Map<IEnumerable<Restaurant>, IEnumerable<RestaurantListingDto>>(
                RestaurantRepository.GetRestaurantsByClique(cliqueId)).OrderByDescending(r => r.Rating);

            return Json(restaurants.ToDataSourceResult(request));
        }
    }
}
