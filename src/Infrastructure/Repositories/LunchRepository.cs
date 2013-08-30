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

        public IQueryable<Restaurant> GetRestaurants()
        {
            return ContextProvider.GetContext<LunchContext>().Query<Restaurant>();
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

        public void Add(State state)
        {
            ContextProvider.GetContext<LunchContext>().Add(state);
        }

        public IQueryable<State> GetStates()
        {
            return FindAll<State>();
        }

        public State GetState(int stateId)
        {
            return FindSingleOrDefault<State>(c => c.StateId == stateId);
        }

        public void DeleteState(State state)
        {
            ContextProvider.GetContext<LunchContext>().Delete(state);
        }

        public void Add(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                Add(state);
            }
        }
    }
}
