using System;
using System.Data;
using System.Web.Mvc;
using Common.Logging;
using Dino;
using LunchPicker.Domain;
using LunchPicker.Domain.Repositories;
using LunchPicker.Web.Framework;

namespace LunchPicker.Web.Areas.Clique.Controllers
{
    public class CliqueController : Controller
    {
        public ICliqueRepository CliqueRepository { get; set; }
        public IClock Clock { get; set; }
        public ISession _Session { get; set; }
        public ILog Log { get; set; }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage(long cliqueId)
        {
            var clique = CliqueRepository.GetClique(cliqueId);
            return View(clique);
        }

        [JsonExceptionFilter]
        public ActionResult Save(Domain.Entities.Clique clique)
        {
            try
            {
                var cliqueS = CliqueRepository.GetClique(clique.CliqueId);

                if(cliqueS == null) 
                    throw new DataException(string.Format("Unable to find a clique with the following id '{0}'", clique.CliqueId));

                cliqueS.Name = clique.Name;
                cliqueS.Update(User);
                _Session.Commit();

                return new JsonResult {Data = "Success"};
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw new Exception(string.Format("Unable to save the Clique. <i>{0}</i>", ex.Message));
            }
        }
    }
}
