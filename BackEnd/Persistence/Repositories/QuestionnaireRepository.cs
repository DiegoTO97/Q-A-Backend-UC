using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Repositories
{
    public class QuestionnaireRepository: IQuestionnaireRepository
    {
        private readonly AplicationDbContext _context;

        public QuestionnaireRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateQuestionnaire(Questionnaire questionnaire)
        {
            _context.Add(questionnaire);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionnaire(Questionnaire questionnare)
        {
            questionnare.Active = 0;
            _context.Entry(questionnare).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<Questionnaire> FindQuestionnaire(int questionnaireId, int userId)
        {
            var questionnaire = await _context.Questionnaire.Where(x => x.Id == questionnaireId && x.Active == 1 && x.UserId == userId).FirstOrDefaultAsync();
            return questionnaire;
        }

        public async Task<List<Questionnaire>> GetListQuestionnaire()
        {
            var questionnaireList = await _context.Questionnaire
                .Where(x => x.Active == 1)
                .Select(o => new Questionnaire
                {
                    Id = o.Id,
                    Name = o.Name,
                    Description = o.Description,
                    CreationDate = o.CreationDate,
                    User = new User { UserName = o.User.UserName}
                })
                .ToListAsync();

            return questionnaireList;
        }

        public async Task<List<Questionnaire>> GetListQuestionnaireByUser(int userId)
        {
            var questionnaireList = await _context.Questionnaire.Where(x => x.Active == 1 && x.UserId == userId).ToListAsync();
            return questionnaireList;
        }

        public async Task<Questionnaire> GetQuestionnaire(int questionnaireId)
        {
            var questionnaire = await _context.Questionnaire
                .Where(x => x.Id == questionnaireId && x.Active == 1)
                .Include(x=> x.questionsList)
                .ThenInclude(x => x.answersList)
                .FirstOrDefaultAsync();

            return questionnaire;
        }
    }
}
