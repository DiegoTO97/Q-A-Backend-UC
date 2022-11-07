using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Description { get; set; }

        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        public List<Answer> answersList { get; set;}
    }
}
