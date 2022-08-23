namespace StudentCenter.Entities.help
{
    public class Demand_Request
    {
        public decimal? Demand_ID { get; set; }
        public decimal? Student_Demand_FK { get; set; }
        public int? Destination_Collage_FK { get; set; }
        public int? Service_FK { get; set; }
        public DateTime? First_Demand_Date { get; set; }
        public DateTime? Last_Demand_Date { get; set; }

        public string? Demand_Barcode { get; set; }
        public string? Demand_Status { get; set; }
        public string? Demand_Result { get; set; }
        public string? Demand_Applicant_Type { get; set; }

    }
}
