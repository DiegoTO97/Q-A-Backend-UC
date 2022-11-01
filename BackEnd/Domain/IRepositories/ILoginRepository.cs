using BackEnd.Domain.Models;

namespace BackEnd.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<User> ValidateUser(User user);
    }
}
