using System.Linq;
using System.Web.Mvc;
using Dino;
using Kendo.Mvc.UI;
using LunchPicker.Domain;
using LunchPicker.Domain.Repositories;
using LunchPicker.Web.Areas.Clique.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests.Website.Areas.Clique.Restaurant
{
    [TestFixture]
    public class AddRestaurant
    {
        private RestaurantController _controller;
        private ILunchRepository _lunchRepository;
        private ControllerContext _controllerContext;
        private ISession _session;
        [SetUp]
        public void Setup()
        {
            _lunchRepository = MockRepository.GenerateMock<ILunchRepository>();
            _session = MockRepository.GenerateMock<ISession>();
            _controllerContext = MockRepository.GenerateMock<ControllerContext>();
            _controllerContext.Stub(s => s.HttpContext.User.Identity.Name).Return("User");

            _controller = new RestaurantController { Clock = new Clock(), LunchRepository = _lunchRepository, ControllerContext = _controllerContext, _Session = _session};
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        [Ignore]
        public void SuccessfullyAdd()
        {
            _controller.ViewData.ModelState.Clear();

            var restaraunt = new LunchPicker.Domain.Entities.Restaurant();

            _controller.AddRestaurant(new DataSourceRequest(), restaraunt);

            Assert.IsTrue(_controller.ViewData.ModelState.Any());
        }
    }
}