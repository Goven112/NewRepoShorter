using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskInforce.DAL.Enums;

namespace TaskInforce.DAL.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Url> URLs { get; set; }

        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }
    }
}
