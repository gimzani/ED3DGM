using EDGM.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EDGM.Services
{
    public class SeedStarSystems
    {
        public static void seed(DataContext context)
        {
            if (context.StarSystems.Count() == 0)
            {
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Merope",
                    json = "{\"name\":\"Merope\",\"coords\":{\"x\":-78.59375,\"y\":-149.625,\"z\":-340.53125},\"information\":{\"allegiance\":\"Federation\",\"government\":\"Democracy\",\"faction\":\"Pleiades Resource Enterprise\",\"factionState\":\"Expansion\",\"population\":850000,\"security\":\"Medium\",\"economy\":\"Industrial\"},\"primaryStar\":{\"type\":\"B (Blue-White) Star\",\"name\":\"Merope\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Merope",
                    json = "{\"name\":\"Merope\",\"coords\":{\"x\":-78.59375,\"y\":-149.625,\"z\":-340.53125},\"information\":{\"allegiance\":\"Independent\",\"government\":\"Corporate\",\"faction\":\"Atlas Research Group\",\"factionState\":\"Outbreak\",\"population\":\"850000\",\"security\":\"Medium\",\"economy\":\"Industrial\"},\"primaryStar\":{\"name\":\"Merope\",\"type\":\"B (Blue-White) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Nervi",
                    json = "{\"name\":\"Nervi\",\"coords\":{\"x\":-74.75,\"y\":-72.71875,\"z\":35.84375},\"information\":{\"allegiance\":\"Independent\",\"government\":\"Feudal\",\"faction\":\"Independent Pilots Armada\",\"factionState\":\"Boom\",\"population\":\"7531412\",\"security\":\"Low\",\"economy\":\"High Tech\"},\"primaryStar\":{\"name\":\"Nervi\",\"type\":\"G (White-Yellow) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Sol",
                    json = "{\"name\":\"Sol\",\"coords\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"information\":{\"allegiance\":\"Federation\",\"government\":\"Democracy\",\"faction\":\"Mother Gaia\",\"factionState\":\"None\",\"population\":\"22780871769\",\"security\":\"High\",\"economy\":\"Refinery\"},\"primaryStar\":{\"name\":\"Sol\",\"type\":\"G (White-Yellow) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Deciat",
                    json = "{\"name\":\"Deciat\",\"coords\":{\"x\":122.625,\"y\":-0.8125,\"z\":-47.28125},\"information\":{\"allegiance\":\"Federation\",\"government\":\"Democracy\",\"faction\":\"Independent Deciat Green Party\",\"factionState\":\"Civil unrest\",\"population\":\"31740050\",\"security\":\"Medium\",\"economy\":\"Industrial\"},\"primaryStar\":{\"name\":\"Deciat\",\"type\":\"K (Yellow-Orange) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Tun",
                    json = "{\"name\":\"Tun\",\"coords\":{\"x\":-47.96875,\"y\":20.96875,\"z\":-17.53125},\"information\":{\"allegiance\":\"Federation\",\"government\":\"Democracy\",\"faction\":\"People's Tun for Equality\",\"factionState\":\"Investment\",\"population\":\"500000\",\"security\":\"Medium\",\"economy\":\"Agriculture\"},\"primaryStar\":{\"name\":\"Tun\",\"type\":\"K (Yellow-Orange) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Candra",
                    json = "{\"name\":\"Candra\",\"coords\":{\"x\":-119.65625,\"y\":-72.1875,\"z\":57.0},\"information\":{\"allegiance\":\"Independent\",\"government\":\"Dictatorship\",\"faction\":\"Constitution Party of Candra\",\"factionState\":\"None\",\"population\":\"949562\",\"security\":\"Low\",\"economy\":\"Industrial\"},\"primaryStar\":{\"name\":\"Candra A\",\"type\":\"T Tauri Star\",\"isScoopable\":false}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Uadjaramin",
                    json = "{\"name\":\"Uadjaramin\",\"coords\":{\"x\":-112.15625,\"y\":-71.25,\"z\":50.03125},\"information\":{\"allegiance\":\"Independent\",\"government\":\"Feudal\",\"faction\":\"Uadjaramin Domain\",\"factionState\":\"Civil war\",\"population\":\"38371\",\"security\":\"Low\",\"economy\":\"Extraction\"},\"primaryStar\":{\"name\":\"Uadjaramin\",\"type\":\"M (Red dwarf) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Gerdisao",
                    json = "{\"name\":\"Gerdisao\",\"coords\":{\"x\":-110.53125,\"y\":-105.625,\"z\":37.125},\"information\":{\"allegiance\":\"Independent\",\"government\":\"Confederacy\",\"faction\":\"Mortis Incorporated\",\"factionState\":\"Expansion\",\"population\":\"171385\",\"security\":\"Low\",\"economy\":\"Extraction\"},\"primaryStar\":{\"name\":\"Gerdisao\",\"type\":\"G (White-Yellow) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Volu",
                    json = "{\"name\":\"Volu\",\"coords\":{\"x\":76.75,\"y\":-5.15625,\"z\":-62.59375},\"information\":{\"allegiance\":\"Federation\",\"government\":\"Confederacy\",\"faction\":\"Volu League\",\"factionState\":\"Boom\",\"population\":\"22008\",\"security\":\"Low\",\"economy\":\"Refinery\"},\"primaryStar\":{\"name\":\"Volu\",\"type\":\"M (Red dwarf) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Kunahpu",
                    json = "{\"name\":\"Kunahpu\",\"coords\":{\"x\":78.46875,\"y\":7.15625,\"z\":-40.25},\"information\":{\"allegiance\":\"Federation\",\"government\":\"Corporate\",\"faction\":\"Neritus Ltd\",\"factionState\":\"Boom\",\"population\":\"551165\",\"security\":\"Medium\",\"economy\":\"Refinery\"},\"primaryStar\":{\"name\":\"Kunahpu\",\"type\":\"M (Red dwarf) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Loha",
                    json = "{\"name\":\"Loha\",\"coords\":{\"x\":78.78125,\"y\":10.90625,\"z\":-49.46875},\"information\":{\"allegiance\":\"Federation\",\"government\":\"Democracy\",\"faction\":\"Democrats of Loha\",\"factionState\":\"Boom\",\"population\":\"23795697\",\"security\":\"Medium\",\"economy\":\"Industrial\"},\"primaryStar\":{\"name\":\"Loha A\",\"type\":\"M (Red dwarf) Star\",\"isScoopable\":true}}"
                });
                context.StarSystems.Add(new StarSystem()
                {
                    Name = "Putama",
                    json = "{\"name\":\"Putama\",\"coords\":{\"x\":80.84375,\"y\":-17.0,\"z\":-45.96875},\"information\":{\"allegiance\":\"Empire\",\"government\":\"Patronage\",\"faction\":\"Putama Imperial Society\",\"factionState\":\"Boom\",\"population\":\"45073279\",\"security\":\"High\",\"economy\":\"Industrial\"},\"primaryStar\":{\"name\":\"Putama A\",\"type\":\"K (Yellow-Orange) Star\",\"isScoopable\":true}}"
                });

                context.SaveChanges();
                

                List<StarSystem> starSystems = context.StarSystems.ToList();
                foreach(StarSystem s in starSystems)
                {
                    context.JournalStarSystems.Add(new JournalStarSystem() { JournalId = 1, StarSystemId = s.Id });
                }
                context.SaveChanges();
            }
        }
    }
}
