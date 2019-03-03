using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDGM.Entities
{
    public class Journal
    {
        //-------------------------------------
        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "VARCHAR"), StringLength(32)]
        public string Name { get; set; }
        
        public string Notes { get; set; }

        //--------------------------------------------------------------
        public ICollection<JournalStarSystem> JournalStarSystems { get; set; }
    }
}
