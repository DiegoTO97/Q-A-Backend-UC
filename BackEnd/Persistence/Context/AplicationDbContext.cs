using BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Context
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Questionnaire> Questionnaire { get; set; }
        public DbSet<Answer> Answer { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
