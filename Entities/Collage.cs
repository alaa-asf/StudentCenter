using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCenter.Entities
{
    [Table("Collage")]
    public class Collage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Collage_ID { get; set; }
        [Required]
        public string? Collage_Name { get; set; }
        public bool? Is_Automated_Work { get; set; }
        public int? Execution_Period_Duration { get; set; }
    }
}
