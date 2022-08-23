using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCenter.Entities
{
    [Table("Student_Demand")]
    public class Student_Demand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public decimal? Student_Demand_ID { get; set; }
        [Required]
        public string? Student_Demand_FirstName { get; set; }
        [Required]
        public string? Student_Demand_LastName { get; set; }
        [Required]
        public string? Student_Demand_National_ID { get; set; }

        [Required]
        public string? Student_Demand_Univercity_Number { get; set; }

        [ForeignKey("Collage")]
        public int? Collage_FK { get; set; }

        public virtual Collage? Collage { get; set; }




    }
}
