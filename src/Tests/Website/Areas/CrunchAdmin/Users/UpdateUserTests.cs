using LunchPicker.Domain.Entities;
using LunchPicker.Web.Areas.CrunchAdmin.Models.Users;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests.Website.Areas.CrunchAdmin.Users
{
    [TestFixture]
    public partial class UsersTests
    {
        [Test]
        [Ignore]
        public void SuccesfullyUpdateUser()
        {
            _session.Expect(a => a.Commit());

            var updateUserObj = new UserModel
                                {
                                    FirstName = "Test",
                                    LastName = "Last",
                                    EmailAddress =
                                        "new_email@shouldBeThere.com",
                                    UserId = 1
                                };

            var currentUserObj = new User
                                 {
                                     FirstName = updateUserObj.FirstName,
                                     LastName = updateUserObj.LastName,
                                     UserId = 1
                                 };

            Assert.IsNullOrEmpty(currentUserObj.EmailAddress, "Email Address should be null.");

            _accountRepository.Expect(a => a.GetUser(updateUserObj.UserId)).Return(currentUserObj);
            
            _controller.UpdateUser(_request, updateUserObj);

            Assert.AreEqual(updateUserObj.EmailAddress, currentUserObj.EmailAddress);
        }
    }
}