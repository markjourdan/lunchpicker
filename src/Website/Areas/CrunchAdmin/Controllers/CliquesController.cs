using System.Linq;
using System.Web.Mvc;
using Dino;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LunchPicker.Domain;
using LunchPicker.Domain.Repositories;
using LunchPicker.Web.Areas.CrunchAdmin.Models.Cliques;

namespace LunchPicker.Web.Areas.CrunchAdmin.Controllers
{
    public class CliquesController : Controller
    {
        public ICliqueRepository CliqueRepository { get; set; }
        public ISession _Session { get; set; }
        public IClock Clock { get; set; }
        public ActionResult Manage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCliques(DataSourceRequest request)
        {
            return Json(CliqueRepository.GetCliques()
                .Select(s => new CliqueModel
                {
                    CliqueId = s.CliqueId,
                    IsActive = s.IsActive,
                    Name = s.Name,
                    FriendlyKey = s.FriendlyKey
                })
                .ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateClique(DataSourceRequest request, CliqueModel cliqueModel)
        {
            if (cliqueModel != null && ModelState.IsValid)
            {
                var target = CliqueRepository.GetClique(cliqueModel.CliqueId);

                if (target != null)
                {
                    target.IsActive = cliqueModel.IsActive;
                    target.Name = cliqueModel.Name;
                    target.Update(User);
                    _Session.Commit();
                }
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpDelete]
        public ActionResult DeleteClique(DataSourceRequest request, CliqueModel cliqueModel)
        {
            if (cliqueModel != null)
            {
                var toDelete = CliqueRepository.GetClique(cliqueModel.CliqueId);
                CliqueRepository.Delete(toDelete);

                _Session.Commit();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        [HttpPut]
        public ActionResult AddClique(DataSourceRequest request, Domain.Entities.Clique clique)
        {
            clique.CreatedDateUtc = clique.CreatedDateUtc = Clock.UtcNow;
            clique.CreatedBy = clique.LastUpdatedBy = User.Identity.Name;

            if (ModelState.IsValid)
            {
                CliqueRepository.Add(clique);

                _Session.Commit();
            }

            return Json(new[] { clique }.ToDataSourceResult(request, ModelState));
        }
    }
}