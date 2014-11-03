﻿using System.Linq;
using System.Web.Mvc;
using Dino;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LunchPicker.Domain;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Factories;
using LunchPicker.Domain.Repositories;
using LunchPicker.Web.Areas.CrunchAdmin.Models.State;

namespace LunchPicker.Web.Areas.CrunchAdmin.Controllers
{
    public class StateController : Controller
    {
        public IStateRepository StateRepository { get; set; }
        public ICreateStates CreateStates { get; set; }
        public ISession _Session { get; set; }
        public IClock Clock { get; set; }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult GetStates(DataSourceRequest request)
        {
            return Json(StateRepository.GetStates().Cast<State>()
                .Select(s => new StateModel
                            {
                                Abreviation = s.Abbreviation,
                                FullName = s.FullName,
                                StateId = s.StateId
                            })
                .ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateAllUSAStates()
        {
            var states = StateRepository.GetStates().ToList();

            StateRepository.Add(CreateStates.USA(states));

            _Session.Commit();

            return RedirectToAction("Manage");
        }

        [HttpPost]
        public JsonResult UpdateState(DataSourceRequest request, State state)
        {
            if (state != null && ModelState.IsValid)
            {
                var target = StateRepository.GetState(state.StateId);

                if (target != null)
                {
                    target.Abbreviation = state.Abbreviation;
                    target.FullName = state.FullName;
                    target.Update(User);
                    _Session.Commit();
                }
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpDelete]
        public ActionResult DeleteState(DataSourceRequest request, State state)
        {
            if (state != null)
            {
                var toDelete = StateRepository.GetState(state.StateId);
                StateRepository.DeleteState(toDelete);

                _Session.Commit();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpPut]
        public ActionResult AddState(DataSourceRequest request, State state)
        {
            state.LastUpdatedDateUtc = state.CreatedDateUtc = Clock.UtcNow;
            state.CreatedBy = state.LastUpdatedBy = User.Identity.Name;

            if (ModelState.IsValid)
            {
                StateRepository.Add(state);

                _Session.Commit();
            }

            return Json(new[] { state }.ToDataSourceResult(request, ModelState));
        }
    }
}
