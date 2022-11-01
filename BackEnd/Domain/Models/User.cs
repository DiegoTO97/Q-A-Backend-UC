using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class User
    {

        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
    }
}
