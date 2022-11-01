using BackEnd.Domain.IServices;

namespace BackEnd.Services
{
    public class LoginService: ILoginService
    {
        private readonly ILoginService _loginService;

        public LoginService(ILoginService loginService)
        {
            _loginService = loginService;
        }

    }
}
