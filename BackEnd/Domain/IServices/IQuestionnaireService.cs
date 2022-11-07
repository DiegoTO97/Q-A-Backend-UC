using BackEnd.Domain.Models;

namespace BackEnd.Domain.IServices
{
    public interface IQuestionnaireService
    {
        Task CreateQuestionnaire(Questionnaire questionnaire);
        Task<List<Questionnaire>> GetListQuestionnaireByUser(int userId);
        Task<Questionnaire> GetQuestionnaire(int questionnaireId);
        Task<Questionnaire> FindQuestionnaire(int questionnaireId, int userId);
        Task DeleteQuestionnaire(Questionnaire questionnare);
        Task<List<Questionnaire>> GetListQuestionnaire();
    }
}
