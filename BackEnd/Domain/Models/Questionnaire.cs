using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
        public int Active { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Question> questionsList { get; set; }


    }
}
