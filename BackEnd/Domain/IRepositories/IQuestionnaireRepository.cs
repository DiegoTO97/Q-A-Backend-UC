using BackEnd.Domain.Models;

namespace BackEnd.Domain.IRepositories
{
    public interface IQuestionnaireRepository
    {
        Task CreateQuestionnaire(Questionnaire questionnaire);
        Task<List<Questionnaire>> GetListQuestionnaireByUser(int userId);
        Task<Questionnaire> GetQuestionnaire(int questionnaireId);
        Task<Questionnaire> FindQuestionnaire(int questionnaireId, int userId);
        Task DeleteQuestionnaire(Questionnaire questionnare);
        Task<List<Questionnaire>> GetListQuestionnaire();
    }
}
