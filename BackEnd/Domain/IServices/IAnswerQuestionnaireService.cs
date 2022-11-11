using BackEnd.Domain.Models;

namespace BackEnd.Domain.IServices
{
    public interface IAnswerQuestionnaireService
    {
        Task SaveAnswerQuestionnaire(AnswerQuestionnaire answerQuestionnaire);
        Task<List<AnswerQuestionnaire>> ListAnswerQuestionnaire(int questionnaireId, int userId);
    }
}
