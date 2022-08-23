using System.ComponentModel.DataAnnotations;

namespace StudentCenter.Entities.help
{
    public class Student_Demand_Request
    {
        public string? Student_Demand_FirstName { get; set; }

        public string? Student_Demand_LastName { get; set; }

        public string? Student_Demand_National_ID { get; set; }

        public string? Student_Demand_Univercity_Number { get; set; }


        public int? Collage_FK { get; set; }


    }
}
