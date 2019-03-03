using EDGM.Entities;
using System.Linq;

namespace EDGM.Services
{
    public class SeedJournals
    {
        public static void seed(DataContext context)
        {
            if (context.Journals.Count() == 0)
            {
                context.Journals.Add(new Journal() { Name = "Commander Gimzani" });
                context.SaveChanges();
            }
        }
    }
}
