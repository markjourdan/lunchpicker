using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Infrastructure.Data.Configurations
{
    public class LanguageConfiguration : EntityTypeConfiguration<Language>
    {
        public LanguageConfiguration()
        {
            HasKey(p => p.LanguageId);
            Property(p => p.LanguageId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.ISOCode);
            Property(p => p.Name);
            Property(p => p.CreatedBy).IsRequired();
            Property(p => p.CreatedDateUtc).IsRequired();
            Property(p => p.LastUpdatedBy).IsRequired();
            Property(p => p.LastUpdatedDateUtc).IsRequired();
            Property(p => p.IsEnabled).IsRequired();
            ToTable("Language");
        }
    }
}
