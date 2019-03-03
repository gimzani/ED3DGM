
using Microsoft.Extensions.Configuration;

namespace EDGM.Services
{
    public class SeedData
    {
        //--------------------------------------------------------------------------------------------
        public static void SeedDatabase(DataContext context, IConfiguration config)
        {
            context.Database.EnsureCreated();
            
            SeedCategories.seed(context);
            SeedColorLabels.seed(context);

            SeedJournals.seed(context);
            SeedStarSystems.seed(context);
        }
        //--------------------------------------------------------------------------------------------
    }
}
