using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AplicationDbContext _context;
        public UserRepository(AplicationDbContext context)
        {
            _context = context;
         }
        public async Task SaveUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> ValidateExistence(User user)
        {
            var validateExistence = await _context.User.AnyAsync(x => x.UserName == user.UserName);

            return validateExistence;
        }

        public async Task<User> ValidatePassword(int userId, string previousPassword)
        {
            var user = await _context.User.Where(x => x.Id == userId && x.Password == previousPassword).FirstOrDefaultAsync();
            return user;
        }

        public async Task UpdatePassword(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
