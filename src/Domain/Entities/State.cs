using System;
using System.Security.Principal;

namespace LunchPicker.Domain.Entities
{
    public class State
    {
        public State()
        {
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public State(IPrincipal user)
        {
            LastUpdatedBy = CreatedBy = user.Identity.Name;
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public int StateId { get; set; }
        public string FullName { get; set; }
        public string Abbreviation { get; set; }

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
