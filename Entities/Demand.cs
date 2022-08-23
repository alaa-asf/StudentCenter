using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCenter.Entities
{
    [Table("Demand")]
    public class Demand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? Demand_ID { get; set; }

        [ForeignKey("Student_Demand")]
        public decimal? Student_Demand_FK { get; set; }
        [ForeignKey("Destination_Collage")]
        public int? Destination_Collage_FK { get; set; }
        public int? Service_FK { get; set; }
        public DateTime? Demand_Date { get; set; }
        public string? Demand_Barcode { get; set; }
        public string? Demand_Status { get; set; }
        public int?  User_Created_FK { get; set; }
        public DateTime? User_Created_Date { get; set; }
        public string? User_Finish_Demand_Note { get; set; }
        public int? User_Finish_Demand_FK { get; set; }
        public DateTime? User_Finish_Demand_Date { get; set; }
        public string? Demand_Result { get; set; }
        public string? Demand_Applicant_Type { get; set; }
        public string? Agency_No { get; set; }
        public DateTime? Agency_Date { get; set; }
        public string? Agency_Source { get; set; }

        public virtual Student_Demand? Student_Demand { get; set; }
        public virtual Collage? Destination_Collage { get; set; }


    }
}
