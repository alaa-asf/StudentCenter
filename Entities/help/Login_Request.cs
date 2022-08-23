using System.ComponentModel.DataAnnotations;

namespace StudentCenter.Entities.help
{
    public class Login_Request
    {
        public string? User_Password { get; set; }
        [Required]
        public string? User_Name { get; set; }
    }
}
