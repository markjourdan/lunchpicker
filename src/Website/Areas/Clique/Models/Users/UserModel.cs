using AutoMapper;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Web.Areas.Clique.Models.Users
{
    public class UserModel
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }

    
    public static class UserExtension
    {
        public static UserModel ToUserModel(this User user)
        {
            return Mapper.Map<UserModel>(user);
        }
    }
}