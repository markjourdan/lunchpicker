using System;
using System.Security.Principal;

namespace LunchPicker.Domain.Entities
{
    public class RestaurantRestaurantType
    {
        public RestaurantRestaurantType()
        {
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public RestaurantRestaurantType(IPrincipal user)
        {
            LastUpdatedBy = CreatedBy = user.Identity.Name;
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public long RestaurantRestaurantTypeId { get; set; }
        public long? RestaurantId { get; set; }
        public long RestaurantTypeId { get; set; }

        public string LastUpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        
        public void Update(IPrincipal user)
        {
            LastUpdatedDateUtc = DateTime.UtcNow;
            LastUpdatedBy = user.Identity.Name;
        }
    }
}
