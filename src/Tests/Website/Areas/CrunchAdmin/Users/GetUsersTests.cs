using System.Collections.Generic;
using LunchPicker.Domain.Entities;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests.Website.Areas.CrunchAdmin.Users
{
    [TestFixture]
    public partial class UsersTests
    {
        [Test]
        public void SuccesfullyGetUsers()
        {
            _accountRepository.Expect(a => a.GetUsers()).Return(new List<User>
                                                                  {
                                                                      new User
                                                                      {
                                                                          FirstName = "Test",
                                                                          LastName = "Last",
                                                                          EmailAddress = "email@emailaddress.com",
                                                                          UserName = "TestLast",
                                                                          UserId = 1
                                                                      }
                                                                  });

            _controller.GetUsers(_request);

            Assert.Pass();
        }
    }
}