using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDGM.Entities
{
    public class StarSystem
    {
        //--------------------------------------
        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "VARCHAR"), StringLength(32)]
        public string Name { get; set; }

        public string json { get; set; }
        //--------------------------------------------------------------
        public StarSystem() { }

        public StarSystem(StarInfo starInfo) {
            Name = starInfo.name;
            json = JsonConvert.SerializeObject(starInfo);
        }
        //--------------------------------------------------------------
        public ICollection<JournalStarSystem> JournalStarSystems { get; set; }
    }
}
