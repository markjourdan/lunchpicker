using System.Collections.Generic;
using System.Linq;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        IQueryable<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(long restaurantId);
        IEnumerable<Restaurant> GetRestaurantsByClique(int cliqueId);
        IQueryable<Restaurant> GetRestaurants(int cliqueId);
        void DeleteRestaurant(Restaurant restaurant);
        void Add(Restaurant restaurant);
    }
}