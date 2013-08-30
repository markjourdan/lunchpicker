using System.Collections.Generic;
using System.Linq;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface ILunchRepository
    {
        IQueryable<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(long restaurantId);
        void DeleteRestaurant(Restaurant restaurant);
        void Add(Restaurant restaurant);
        void Add(State state);
        IQueryable<State> GetStates();
        State GetState(int stateId);
        void DeleteState(State state);
        void Add(IEnumerable<State> states);
    }
}
