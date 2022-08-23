using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCenter.Entities
{
    [Table("Service_Document_Required")]
    public class Service_Document_Required
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Document_Required_Service_ID { get; set; }
        [ForeignKey("Service")]
        public int? Service_FK { get; set; }
        [Required]
        public string? Document_Required_Service_Name { get; set; }
    }
}
