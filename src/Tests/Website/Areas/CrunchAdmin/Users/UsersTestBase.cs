using Dino;
using Kendo.Mvc.UI;
using LunchPicker.Domain;
using LunchPicker.Domain.Repositories;
using LunchPicker.Web.Areas.CrunchAdmin.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests.Website.Areas.CrunchAdmin.Users
{
    public partial class UsersTests
    {
        private IAccountRepository _accountRepository;
        private IClock _clock;
        private ISession _session;
        private UsersController _controller;
        private DataSourceRequest _request;

        [SetUp]
        public void SetUp()
        {
            _request = new DataSourceRequest();

            _accountRepository = MockRepository.GenerateMock<IAccountRepository>();
            _clock = MockRepository.GenerateStub<IClock>();
            _session = MockRepository.GenerateMock<ISession>();

            _controller = new UsersController
            {
                Clock = _clock,
                AccountRepository = _accountRepository,
                _Session = _session
            };
        }

        [TearDown]
        public void TearDown()
        {
            _accountRepository.VerifyAllExpectations();
            _clock.VerifyAllExpectations();
        }
    }
}
