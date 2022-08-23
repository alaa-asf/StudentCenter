using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCenter.Entities
{
    [Table("Service")]
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Service_ID { get; set; }
        [Required]
        public string? Service_Name { get; set; }

        public virtual List<Service_Document_Required>? Service_Document_Required { get; set; }

    }
}
