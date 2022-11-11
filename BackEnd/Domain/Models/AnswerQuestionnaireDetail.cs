namespace BackEnd.Domain.Models
{
    public class AnswerQuestionnaireDetail
    {
        public int Id { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }

        public int AnswerQuestionnaireId { get; set; }
        /*    public AnswerQuestionnaire AnswerQuestionnaire { get; set; }*/

    }
}
