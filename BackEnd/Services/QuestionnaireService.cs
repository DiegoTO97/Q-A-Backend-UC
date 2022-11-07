using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;

namespace BackEnd.Services
{
    public class QuestionnaireService: IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;

        public QuestionnaireService(IQuestionnaireRepository questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }

        public async Task CreateQuestionnaire(Questionnaire questionnaire)
        {
            await _questionnaireRepository.CreateQuestionnaire(questionnaire);
        }

        public async Task DeleteQuestionnaire(Questionnaire questionnare)
        {
            await _questionnaireRepository.DeleteQuestionnaire(questionnare);
        }

        public async Task<Questionnaire> FindQuestionnaire(int questionnaireId, int userId)
        {
            return await _questionnaireRepository.FindQuestionnaire(questionnaireId, userId);
        }

        public async Task<List<Questionnaire>> GetListQuestionnaire()
        {
            return await _questionnaireRepository.GetListQuestionnaire();
        }

        public async Task<List<Questionnaire>> GetListQuestionnaireByUser(int userId)
        {
            return await _questionnaireRepository.GetListQuestionnaireByUser(userId);
        }

        public async Task<Questionnaire> GetQuestionnaire(int questionnaireId)
        {
            return await _questionnaireRepository.GetQuestionnaire(questionnaireId);
        }


    }
}
