using System;
using System.Security.Principal;

namespace LunchPicker.Domain.Entities
{
    public class UserClique
    {
        public UserClique()
        {
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public UserClique(IPrincipal user)
        {
            LastUpdatedBy = CreatedBy = user.Identity.Name;
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public long UserId { get; set; }
        public long CliqueId { get; set; }

        public virtual User User { get; set; }
        public virtual Clique Clique { get; set; }

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