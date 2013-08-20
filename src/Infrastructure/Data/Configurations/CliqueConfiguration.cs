using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Infrastructure.Data.Configurations
{
    public class CliqueConfiguration : EntityTypeConfiguration<Clique>
    {
        public CliqueConfiguration()
        {
            HasKey(p => p.CliqueId);
            Property(p => p.CliqueId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name);
            Property(p => p.CreatedBy).IsRequired();
            Property(p => p.CreatedDateUtc).IsRequired();
            Property(p => p.LastUpdatedBy).IsRequired();
            Property(p => p.LastUpdatedDateUtc).IsRequired();
            Property(p => p.IsActive).IsRequired();
            ToTable("Clique");
        }
    }
}
