using System.Web.Mvc;
using LunchPicker.Web.Controllers;
using NUnit.Framework;

namespace Tests.Website.Home
{
    [TestFixture]
    public class DisplayHomePage
    {
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new HomeController();
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void HomepageExists()
        {
            var result = _controller.Index() as ViewResult;

            Assert.NotNull(result);
        }

        [Test]
        public void RestuarantRankingExsits()
        {
            var result = _controller.RestaurantRanking() as ViewResult;

            Assert.NotNull(result);
        }
    }
}