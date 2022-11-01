using BackEnd.Domain.IRepositories;

namespace BackEnd.Persistence.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly ILoginRepository _loginRepository;

        public LoginRepository(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

    }
}
