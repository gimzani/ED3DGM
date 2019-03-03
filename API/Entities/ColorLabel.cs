using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDGM.Entities
{
    public class ColorLabel
    {
        //-------------------------------------
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required, Column(TypeName = "VARCHAR"), StringLength(32)]
        public string Name { get; set; }

        [Required, Column(TypeName = "VARCHAR"), StringLength(32)]
        public string Color { get; set; }

        //--------------------------------------------------------------
        public Category Category { get; set; }
    }
}
