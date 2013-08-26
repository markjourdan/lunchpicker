using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace LunchPicker.Domain.Entities
{
    public class Restaurant
    {
        public Restaurant()
        {
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public Restaurant(IPrincipal user)
        {
            LastUpdatedBy = CreatedBy = user.Identity.Name;
            LastUpdatedDateUtc = CreatedDateUtc = DateTime.UtcNow;
        }

        public long RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public long CliqueId { get; set; }

        public string LastUpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedDateUtc { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public virtual State State { get; set; }
        public virtual Clique Clique { get; set; }

        public virtual ICollection<RestaurantRating> RestaurantRatings { get; set; }

        public string GetHtmlFormattedAddress()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(Address1);
            stringBuilder.AppendLine("<br />");
            if (!String.IsNullOrEmpty(Address2))
            {
                stringBuilder.AppendLine(Address2);
                stringBuilder.AppendLine("<br />");
            }

            stringBuilder.AppendLine(City);

            if (State != null)
            {
                stringBuilder.AppendLine(", ");
                stringBuilder.AppendLine(State.Abreviation);
            }

            stringBuilder.AppendLine(" ");
            stringBuilder.AppendLine(Zip);

            return stringBuilder.ToString();
        }

        public string GetSingleLineAddress()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(Address1);
            stringBuilder.Append(",");
            if (!String.IsNullOrEmpty(Address2))
            {
                stringBuilder.Append(Address2);
                stringBuilder.Append(",");
            }

            stringBuilder.Append(City);
            stringBuilder.Append(", ");
            stringBuilder.Append(State.Abreviation);
            stringBuilder.Append(" ");
            stringBuilder.Append(Zip);

            return stringBuilder.ToString();
        }

        public void Update(IPrincipal user)
        {
            LastUpdatedDateUtc = DateTime.UtcNow;
            LastUpdatedBy = user.Identity.Name;
        }
    }
}
