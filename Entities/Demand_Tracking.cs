using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentCenter.Entities
{
    public class Demand_Tracking
    {
       
        public decimal? Record_ID { get; set; }
        public string? Record_Type { get; set; }

        public decimal? Demand_FK { get; set; }
        public DateTime? Demand_Date { get; set; }
        public string? Demand_Barcode { get; set; }
        public string? Demand_Status { get; set; }
        public string? Demand_Result { get; set; }
        public string? Demand_Applicant_Type { get; set; }
        public string? Agency_No { get; set; }
        public DateTime? Agency_Date { get; set; }
        public string? Agency_Source { get; set; }

        public string? Student_Demand_FirstName { get; set; }
        
        public string? Student_Demand_LastName { get; set; }
        
        public string? Student_Demand_National_ID { get; set; }

        
        public string? Student_Demand_Univercity_Number { get; set; }





        public int? Collage_FK { get; set; }
        public string? Collage_Name { get; set; }



        public string? Type { get; set; }
        public String? Diwan_NO { get; set; }
        public DateTime? Diwan_Date { get; set; }


        public string? Reporter_Name { get; set; }

      
    }
}
