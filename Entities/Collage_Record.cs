using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCenter.Entities
{
    [Table("Collage_Record")]
    public class Collage_Record
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? Collage_Records_ID {get; set;}

        [ForeignKey("Demand")]
        public decimal? Demand_FK   	{get; set;}
        [ForeignKey("Collage")]
        public int? Collage_FK { get; set; }
        [Required]
        public string? Type { get; set; }
    public string?  Diwan_NO { get; set; }
    public DateTime? Diwan_Date  {get; set;}
    public string?  Reporter_Name { get; set; }

        public virtual Demand? Demand { get; set; }
        public virtual Collage? Collage { get; set; }

    }
}
