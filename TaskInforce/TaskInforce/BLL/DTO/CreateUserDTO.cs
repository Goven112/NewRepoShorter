using System.ComponentModel.DataAnnotations;

namespace TaskInforce.BLL.DTO
{
    public class CreateUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]//magic numbers
        public string Password { get; set; }
    }
}
