using System.Linq;
using AutoMapper;
using LunchPicker.Domain.DataTransferObject;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Web.App_Start
{
    public static class AutoMapperMapping
    {
        public static void Map()
        {
            Mapper.CreateMap<Restaurant, RestaurantListingDto>()
               .ForMember(dest => dest.Rating, opt => opt.MapFrom(origin => origin.Ratings.Any() ? origin.Ratings.Sum(r => r.Rating.Description) : 0));

            Mapper.CreateMap<User, Areas.Clique.Models.Users.UserModel>();

            Mapper.CreateMap<Clique, Areas.CrunchAdmin.Models.Users.CliqueModel>();

            Mapper.CreateMap<User, Areas.CrunchAdmin.Models.Users.UserModel>();

        }
    }
}