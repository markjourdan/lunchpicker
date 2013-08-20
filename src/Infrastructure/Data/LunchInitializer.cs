using System.Data.Entity;

namespace LunchPicker.Infrastructure.Data
{
    public class LunchInitializer : CreateDatabaseIfNotExists<LunchContext>
    {
    }
}