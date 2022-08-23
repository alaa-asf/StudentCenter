using System.ComponentModel.DataAnnotations;

namespace StudentCenter.Entities.help
{
    public class Collage_Record_Request
    {
        public decimal? Collage_Records_ID { get; set; }
        public decimal? Demand_FK { get; set; }
        public int? Collage_FK { get; set; }
       
        public string? Type { get; set; }
        public string? Diwan_NO { get; set; }
        public DateTime? First_Diwan_Date { get; set; }
        public DateTime? Last_Diwan_Date { get; set; }

        public string? Reporter_Name { get; set; }

      

    }
}
