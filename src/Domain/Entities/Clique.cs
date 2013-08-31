using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace LunchPicker.Domain.Entities
{
    public class Clique
    {
        public Clique()
        {
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
            FriendlyKey = Guid.NewGuid();
        }

        public Clique(IPrincipal user)
        {
            LastUpdatedBy = CreatedBy = user.Identity.Name;
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
            FriendlyKey = Guid.NewGuid();
        }
        
        public long CliqueId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid FriendlyKey { get; private set; }
        
        public string LastUpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public void Update(IPrincipal user)
        {
            LastUpdatedDateUtc = DateTime.UtcNow;
            LastUpdatedBy = user.Identity.Name;
        }
    }
}
