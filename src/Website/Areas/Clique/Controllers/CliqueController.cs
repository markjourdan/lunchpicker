using System;
using System.Security.Principal;
using System.Web.Mvc;
using Common.Logging;
using Dino;
using LunchPicker.Domain;
using LunchPicker.Domain.Repositories;

namespace LunchPicker.Web.Areas.Clique.Controllers
{
    public class CliqueController : Controller
    {
        public IAccountRepository AccountRepository { get; set; }
        public IClock Clock { get; set; }
        public ISession _Session { get; set; }
        public ILog Log { get; set; }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Save(Domain.Entities.Clique clique)
        {
            try
            {
                var cliqueS = AccountRepository.GetClique(clique.CliqueId);

                cliqueS.Name = clique.Name;
                cliqueS.Update(User);
                _Session.Commit();

                return new JsonResult {Data = "Success"};
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return new JsonResult { Data = ex.Message };
            }
        }
    }
}
