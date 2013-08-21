using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Infrastructure.Data.Configurations
{
    public class RestaurantConfiguration : EntityTypeConfiguration<Restaurant>
    {
        public RestaurantConfiguration()
        {
            HasKey(p => p.RestaurantId);
            Property(p => p.RestaurantId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name);
            Property(p => p.Address1);
            Property(p => p.Address2);
            Property(p => p.City);
            Property(p => p.StateId);
            Property(p => p.Zip);
            Property(p => p.Phone);
            Property(p => p.CliqueId);
            Property(p => p.CreatedBy).IsRequired();
            Property(p => p.CreatedDateUtc).IsRequired();
            Property(p => p.LastUpdatedBy).IsRequired();
            Property(p => p.LastUpdatedDateUtc).IsRequired();
            ToTable("Restaurant");
        }
    }
}