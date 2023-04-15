using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskInforce.DAL.Models
{
    public class Url
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
