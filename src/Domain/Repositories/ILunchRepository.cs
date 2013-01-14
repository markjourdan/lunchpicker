using System.Collections.Generic;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface ILunchRepository
    {
        IEnumerable<Restaurant> GetResturants();
        Restaurant GetResturant(int restaurantId);
    }
}
