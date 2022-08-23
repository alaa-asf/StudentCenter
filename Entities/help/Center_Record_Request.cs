using System.ComponentModel.DataAnnotations;

namespace StudentCenter.Entities.help
{
    public class Center_Record_Request
    {
        
        
        public decimal? Demand_FK { get; set; }

        public decimal? Collage_FK { get; set; }

        public string? Type { get; set; }
        public String? Diwan_NO { get; set; }

        public DateTime? First_Diwan_Date { get; set; }
        public DateTime? Last_Diwan_Date { get; set; }
        public string? Reporter_Name { get; set; }

    }
}
