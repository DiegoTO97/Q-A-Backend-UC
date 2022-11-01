using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly AplicationDbContext _context;

        public LoginRepository (AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateUser(User user)
        {
            var userValidate = await _context.User.Where(x => 
            x.UserName == user.UserName && x.Password == user.Password)
            .FirstOrDefaultAsync();

            return userValidate;
        }
    }
}
