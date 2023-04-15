using System.ComponentModel.DataAnnotations;

namespace TaskInforce.BLL.DTO
{
    public class AuthDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
