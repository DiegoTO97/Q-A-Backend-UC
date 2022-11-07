using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }

    }
}
