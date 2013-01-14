using System;
using System.Security.Principal;

namespace LunchPicker.Domain.Entities
{
    public class Rating
    {
        public Rating()
        {
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public Rating(IPrincipal user)
        {
            LastUpdatedBy = CreatedBy = user.Identity.Name;
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public long RatingId { get; set; }
        public int Description { get; set; }
        public string Message { get; set; }
        public Guid? UserId { get; set; }

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
