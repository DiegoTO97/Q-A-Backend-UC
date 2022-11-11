﻿using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Repositories
{
    public class AnswerQuestionnaireRepository: IAnswerQuestionnaireRepository
    {
        private readonly AplicationDbContext _context;
        public AnswerQuestionnaireRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnswerQuestionnaire>> ListAnswerQuestionnaire(int questionnaireId, int userId)
        {
            var listAnswerQuestionnaire = await _context.AnswerQuestionnaire.Where(x =>
            x.QuestionnaireId == questionnaireId && x.Active == 1 && x.Questionnaire.UserId == userId)
            .OrderByDescending(x => x.Date).ToListAsync();

            return listAnswerQuestionnaire;           
        }

        public async Task SaveAnswerQuestionnaire(AnswerQuestionnaire answerQuestionnaire)
        {
            answerQuestionnaire.Active = 1;
            answerQuestionnaire.Date = DateTime.Now;
            _context.Add(answerQuestionnaire);
            await _context.SaveChangesAsync();
        }
    }
}
