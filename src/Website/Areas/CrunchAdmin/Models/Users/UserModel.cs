using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Web.Areas.CrunchAdmin.Models.Users
{
    public class UserModel
    {
        public long UserId { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        public List<CliqueModel> Cliques { get; set; }
    }

    
    public static class UserExtension
    {
        public static UserModel ToUserModel(this User user)
        {
            return Mapper.Map<UserModel>(user);
        }
    }
}