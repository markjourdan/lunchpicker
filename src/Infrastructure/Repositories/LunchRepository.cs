using System.Collections.Generic;
using Dino;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Infrastructure.Data;

namespace LunchPicker.Infrastructure.Repositories
{
    public class LunchRepository : RepositoryBase, ILunchRepository
    {
        public LunchRepository(IObjectContextProvider contextProvider) : base(contextProvider) { }

        public IEnumerable<Restaurant> GetResturants()
        {
            return ContextProvider.GetContext<LunchContext>().Query<Restaurant>();
        }

        public Restaurant GetResturant(int restaurantId)
        {
            return FindSingleOrDefault<Restaurant>(r => r.RestaurantId == restaurantId);
        }
    }
}
