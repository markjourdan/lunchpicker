using System.Linq;
using AutoMapper;
using LunchPicker.Domain.DataTransferObject;
using LunchPicker.Domain.Entities;
using LunchPicker.Web.Areas.Clique.Models.Users;

namespace LunchPicker.Web.App_Start
{
    public static class AutoMapperMapping
    {
        public static void Map()
        {
            Mapper.CreateMap<Restaurant, RestaurantListingDto>()
               .ForMember(dest => dest.Rating, opt => opt.MapFrom(origin => origin.Ratings.Any() ? origin.Ratings.Sum(r => r.Rating.Description) : 0));

            Mapper.CreateMap<User, UserModel>();
        }
    }
}