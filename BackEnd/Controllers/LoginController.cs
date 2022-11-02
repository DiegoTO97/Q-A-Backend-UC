using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;

        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                user.Password = Encrypt.EncryptPassword(user.Password);
                var userValidate = await _loginService.ValidateUser(user);
                
                if (userValidate == null)
                {
                   return BadRequest(new { message = "User or password invalid" });
                }
                string tokenString = JwtConfigurator.GetToken(userValidate, _config);
                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
