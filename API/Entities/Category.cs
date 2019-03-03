using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDGM.Entities
{
    public class Category
    {
        //-------------------------------------
        [Key]
        public int Id { get; set; }
        
        [Required, Column(TypeName = "VARCHAR"), StringLength(32)]
        public string Name { get; set; }
        
        //--------------------------------------------------------------
        public List<ColorLabel> ColorLabels { get; set; }
    }
}
