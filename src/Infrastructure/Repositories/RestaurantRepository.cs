using System.Collections.Generic;
using System.Linq;
using Dino;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Infrastructure.Data;

namespace LunchPicker.Infrastructure.Repositories
{
    public class RestaurantRepository : RepositoryBase, IRestaurantRepository
    {
        public RestaurantRepository(IObjectContextProvider contextProvider) : base(contextProvider)
        {
        }

        public IQueryable<Restaurant> GetRestaurants()
        {
            return ContextProvider.GetContext<LunchContext>().Query<Restaurant>();
        }

        public IEnumerable<Restaurant> GetRestaurantsByClique(int cliqueId)
        {
            return FindSingleOrDefault<Clique>(c => c.CliqueId == cliqueId).Restaurants;
        }


        public IQueryable<Restaurant> GetRestaurants(int cliqueId)
        {
            return Find<Restaurant>(c => c.CliqueId == cliqueId);
        }

        public Restaurant GetRestaurant(long restaurantId)
        {
            return FindSingleOrDefault<Restaurant>(r => r.RestaurantId == restaurantId);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            ContextProvider.GetContext<LunchContext>().Delete(restaurant);
        }

        public void Add(Restaurant restaurant)
        {
            ContextProvider.GetContext<LunchContext>().Add(restaurant);
        }
    }
}
