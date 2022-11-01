using BackEnd.Domain.Models;

namespace BackEnd.Domain.IServices
{
    public interface ILoginService
    {
        Task<User> ValidateUser(User user);
    }
}
