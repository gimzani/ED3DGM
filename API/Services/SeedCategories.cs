using EDGM.Entities;
using System.Linq;

namespace EDGM.Services
{
    public class SeedCategories
    {
        public static void seed(DataContext context)
        {
            if (context.Categories.Count() == 0)
            {
                context.Categories.Add(new Category() { Name = "Allegiance" });
                context.Categories.Add(new Category() { Name = "Economy" });
                context.Categories.Add(new Category() { Name = "Government" });
                context.SaveChanges();
            }
        }
    }
}
