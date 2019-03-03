using EDGM.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EDGM.Services
{
    public class SeedColorLabels
    {
        public static void seed(DataContext context)
        {

            List<Category> groups = context.Categories.ToList();

            Category allegiance = groups.FirstOrDefault(g => g.Name == "Allegiance");
            Category economy = groups.FirstOrDefault(g => g.Name == "Economy");
            Category government = groups.FirstOrDefault(g => g.Name == "Government");

            if (context.ColorLabels.Count() == 0)
            {
                context.ColorLabels.Add(new ColorLabel() { CategoryId = allegiance.Id, Name = "None", Color = "444442" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = allegiance.Id, Name = "Empire", Color = "FC0708" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = allegiance.Id, Name = "Independent", Color = "12FC2F" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = allegiance.Id, Name = "Federation", Color = "0EC4FA" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = allegiance.Id, Name = "Alliance", Color = "FF991B" });

                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "None", Color = "444442" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "Extraction", Color = "FF0000" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "Refinery", Color = "FF7F00" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "Industrial", Color = "FFFF00" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "Agricultural", Color = "7FFF00" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "Terraforming", Color = "009900" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "High Tech", Color = "00FFFF" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "Colony", Color = "337FFF" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "Service", Color = "0045FF" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "Tourism", Color = "6600E5" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = economy.Id, Name = "Military", Color = "E500E5" });

                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "None", Color = "B2B2B2" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Anarchy", Color = "FFD400" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Colony", Color = "BFFF00" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Democracy", Color = "55FF00" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Imperial", Color = "00FF15" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Corporate", Color = "00FF80" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Communism", Color = "00FFEA" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Feudal", Color = "00AAFF" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Dictatorship", Color = "0040FF" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Theocracy", Color = "2A00FF" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Cooperative", Color = "9500FF" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Patronage", Color = "FF00FF" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Confederacy", Color = "FF0000" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "PrisonColony", Color = "FF6A00" });
                context.ColorLabels.Add(new ColorLabel() { CategoryId = government.Id, Name = "Workshop", Color = "7F7F7F" });
                context.SaveChanges();
            }
        }
    }
}
