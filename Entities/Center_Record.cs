using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCenter.Entities
{
    [Table("Center_Record")]
    public class Center_Record
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal?  Center_Record_ID {get; set;}
        [Required]
        [ForeignKey("Demand")]
        public decimal? Demand_FK { get; set; }

        [ForeignKey("Collage")]
        public int? Collage_FK { get; set; }

        public string? Type { get; set; }
        public String? Diwan_NO { get; set; }
        public DateTime? Diwan_Date { get; set; }


        public string? Reporter_Name { get; set; }

        [ForeignKey("Demand_FK")]
        public virtual Demand? Demand { get; set; }
        [ForeignKey("Collage_FK")]
        public virtual Collage? Collage { get; set; }

    }
}
