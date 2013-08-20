using System.Collections.Generic;
using System.Linq;
using Dino;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Infrastructure.Data;

namespace LunchPicker.Infrastructure.Repositories
{
    public class LunchRepository : RepositoryBase, ILunchRepository
    {
        public LunchRepository(IObjectContextProvider contextProvider) : base(contextProvider) { }

        public IQueryable<Restaurant> GetResturants()
        {
            return ContextProvider.GetContext<LunchContext>().Query<Restaurant>();
        }

        public Restaurant GetResturant(long restaurantId)
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

        public IQueryable<State> GetStates()
        {
            return FindAll<State>();
        }

        public State GetState(int stateId)
        {
            return FindSingleOrDefault<State>(c => c.StateId == stateId);
        }
    }
}
