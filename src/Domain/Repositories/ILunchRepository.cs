using System.Collections.Generic;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface ILunchRepository
    {
        IEnumerable<Restaurant> GetResturants();
        Restaurant GetResturant(long restaurantId);
        void DeleteRestaurant(Restaurant restaurant);
        void Add(Restaurant restaurant);
    }
}
