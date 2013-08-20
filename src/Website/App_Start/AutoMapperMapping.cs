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
               .ForMember(dest => dest.Rating, opt => opt.MapFrom(origin => origin.RestaurantRatings.Any() ? origin.RestaurantRatings.Sum(r => r.Rating.Description) : 0));

        }
    }
}