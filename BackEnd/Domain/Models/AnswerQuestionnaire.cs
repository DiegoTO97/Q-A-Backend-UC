using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class AnswerQuestionnaire
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string ParticipantName { get; set; }

        public DateTime Date { get; set; }
        public int Active { get; set; }

        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }           
        public List<AnswerQuestionnaireDetail> ListAnsQuestionnaireDetail { get; set; }

    }
}
