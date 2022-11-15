using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;

namespace BackEnd.Services
{
    public class AnswerQuestionnaireService: IAnswerQuestionnaireService
    {
        private readonly IAnswerQuestionnaireRepository _answerQuestionnaireRespository;

        public AnswerQuestionnaireService(IAnswerQuestionnaireRepository answerQuestionnaireRespository)
        {
            _answerQuestionnaireRespository = answerQuestionnaireRespository;

        }

        public async Task DeleteAnwserQuestionnaire(AnswerQuestionnaire answerQuestionnaire)
        {
            await _answerQuestionnaireRespository.DeleteAnwserQuestionnaire(answerQuestionnaire);
        }

        public async Task<AnswerQuestionnaire> FindAnswerQuestionnaire(int ansQuestionnaireId, int userId)
        {
            return await _answerQuestionnaireRespository.FindAnswerQuestionnaire(ansQuestionnaireId, userId);
        }

        public async Task<List<AnswerQuestionnaire>> ListAnswerQuestionnaire(int questionnaireId, int userId)
        {
            return await _answerQuestionnaireRespository.ListAnswerQuestionnaire(questionnaireId, userId);
        }

        public async Task SaveAnswerQuestionnaire(AnswerQuestionnaire answerQuestionnaire)
        {
            await _answerQuestionnaireRespository.SaveAnswerQuestionnaire(answerQuestionnaire);
        }
    }
}
