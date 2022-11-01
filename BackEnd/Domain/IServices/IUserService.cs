using BackEnd.Domain.Models;

namespace BackEnd.Domain.IServices
{
    public interface IUserService
    {
        Task SaveUser(User user);
        Task<bool> ValidateExistence(User user);
        Task<User> ValidatePassword(int userId, string previousPassword);
        Task UpdatePassword(User user);
    }
}
