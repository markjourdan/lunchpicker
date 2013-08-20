using System.Linq;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface ILunchRepository
    {
        IQueryable<Restaurant> GetResturants();
        Restaurant GetResturant(long restaurantId);
        void DeleteRestaurant(Restaurant restaurant);
        void Add(Restaurant restaurant);
        IQueryable<State> GetStates();
        State GetState(int stateId);
    }
}
