﻿using System.Linq;
using System.Web.Mvc;
using Dino;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LunchPicker.Domain;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Web.Areas.CrunchAdmin.Models.Users;

namespace LunchPicker.Web.Areas.CrunchAdmin.Controllers
{
    public class UsersController : Controller
    {
        public IAccountRepository AccountRepository { get; set; }
        public ISession _Session { get; set; }
        public IClock Clock { get; set; }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult GetUsers(DataSourceRequest request)
        {
            return Json(AccountRepository.GetUsers()
                .Select(u => new UserModel
                {
                    EmailAddress = u.EmailAddress,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserId = u.UserId,
                    UserName = u.UserName
                })
                .ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUser(DataSourceRequest request, UserModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                var target = AccountRepository.GetUser(user.UserId);

                if (target != null)
                {
                    target.UserName = user.UserName;
                    target.FirstName = user.FirstName;
                    target.LastName = user.LastName;
                    target.EmailAddress = user.EmailAddress;
                    _Session.Commit();
                }
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpDelete]
        public ActionResult DeleteUser(DataSourceRequest request, UserModel user)
        {
            if (user != null)
            {
                var userToDelete = AccountRepository.GetUser(user.UserId);
                AccountRepository.DeleteUser(userToDelete);

                _Session.Commit();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpPut]
        public ActionResult AddUser(DataSourceRequest request, User user)
        {
            user.LastUpdatedDateUtc = user.CreatedDateUtc = Clock.UtcNow;
            user.CreatedBy = user.LastUpdatedBy = User.Identity.Name;

            if (ModelState.IsValid)
            {
                AccountRepository.AddUser(user);

                _Session.Commit();
            }

            return Json(new[] { user.ToUserModel() }.ToDataSourceResult(request, ModelState));
        }
    }
}