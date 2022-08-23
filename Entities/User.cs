using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCenter.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_ID { get; set; }
        [Required]
        public string? User_First_FirstName { get; set; }
        [Required]
        public string? User_First_LastName { get; set; }
        [Required]
        public string? User_Password { get; set; }
        [Required]
        public string? User_Name { get; set; }
        public int? Collage_FK { get; set; }
        public string? User_Type { get; set; }
    }
}
