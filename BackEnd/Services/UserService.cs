using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;

namespace BackEnd.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SaveUser(User user)
        {
            await _userRepository.SaveUser(user);
        }

        public async Task<bool> ValidateExistence(User user)
        {
            return await _userRepository.ValidateExistence(user);
        }

        public async Task<User> ValidatePassword(int userId, string previousPassword)
        {
            return await _userRepository.ValidatePassword(userId, previousPassword);
        }

        public async Task UpdatePassword(User user)
        {
            await _userRepository.UpdatePassword(user);
        }
    }
}
