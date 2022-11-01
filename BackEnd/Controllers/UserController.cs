using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.DTO;
using BackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                var validateExistence = await _userService.ValidateExistence(user);

                if (validateExistence)
                {
                    return BadRequest(new { message = "The user " + user.UserName + " already exist" });
                }

                user.Password = Encrypt.EncryptPassword(user.Password);
                await _userService.SaveUser(user);

                return Ok(new { message = "User registered succesfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //localhost:xxx/api/User/ChangePassword
        [Route("ChangePassword")]
        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePassword)
        {
            try
            {
                int idUser = 3;
                string passwordEncrypt = Encrypt.EncryptPassword(changePassword.previousPassword);
                var user = await _userService.ValidatePassword(idUser, passwordEncrypt);

                if(user == null)
                {
                    return BadRequest(new { message = "The password is wrong" });
                
                }

                user.Password = Encrypt.EncryptPassword(changePassword.newPassword);
                await _userService.UpdatePassword(user);
                return Ok(new { message = "The password was update succesfuly" });
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
    }
}
