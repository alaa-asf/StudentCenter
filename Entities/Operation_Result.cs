using System.Text.Json.Serialization;

namespace StudentCenter.Entities
{
    public class Operation_Result
    {
        [JsonIgnore()]

        public object Result { get; set; }


        public bool SUCCESS { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public string? ERROR_CODE { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public string? ERROR { get; set; }
    }
}
