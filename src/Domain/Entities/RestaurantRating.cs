using System;
using System.Security.Principal;

namespace LunchPicker.Domain.Entities
{
    public class RestaurantRating
    {
        public RestaurantRating()
        {
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public RestaurantRating(IPrincipal user)
        {
            LastUpdatedBy = CreatedBy = user.Identity.Name;
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public long RestaurantRatingId { get; set; }
        public long RestaurantId { get; set; }
        public long RatingId { get; set; }

        public string LastUpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public virtual Rating Rating { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public void Update(IPrincipal user)
        {
            LastUpdatedDateUtc = DateTime.UtcNow;
            LastUpdatedBy = user.Identity.Name;
        }
    }
}
