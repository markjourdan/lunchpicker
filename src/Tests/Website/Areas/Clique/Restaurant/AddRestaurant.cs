using LunchPicker.Web.Areas.Clique.Controllers;
using NUnit.Framework;

namespace Tests.Website.Areas.Clique.Restaurant
{
    [TestFixture]
    public class AddRestaurant
    {
        private RestaurantController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new RestaurantController();
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void SuccessfullyAdd()
        {

        }
    }
}