using BackEnd.Domain.Models;

namespace BackEnd.Domain.IRepositories
{
    public interface IAnswerQuestionnaireRepository
    {
        Task SaveAnswerQuestionnaire(AnswerQuestionnaire answerQuestionnaire);
        Task<List<AnswerQuestionnaire>> ListAnswerQuestionnaire(int questionnaireId, int userId);
        Task<AnswerQuestionnaire> FindAnswerQuestionnaire(int ansQuestionnaireId, int userId);
        Task DeleteAnwserQuestionnaire(AnswerQuestionnaire answerQuestionnaire);
    }
}
