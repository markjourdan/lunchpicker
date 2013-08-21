using System.Data.Entity;
using Dino.EntityFramework;
using LunchPicker.Infrastructure.Data.Configurations;

namespace LunchPicker.Infrastructure.Data
{
    public class LunchContext : ObjectContext
    {
        public LunchContext()
        {
            Database.SetInitializer(new LunchInitializer());
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CliqueConfiguration());
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            modelBuilder.Configurations.Add(new RestaurantConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
