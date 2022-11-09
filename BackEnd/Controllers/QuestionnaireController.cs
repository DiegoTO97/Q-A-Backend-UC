using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;

        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }
        
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody]Questionnaire questionnaire)
        {
            try 
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userId = JwtConfigurator.GetTokenUserId(identity);

                questionnaire.UserId = userId;
                questionnaire.Active = 1;
                questionnaire.CreationDate = DateTime.Now;
                await _questionnaireService.CreateQuestionnaire(questionnaire);

                return Ok(new { message = "The questionnaire was added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListQuestionnaireByUser")]
        [HttpGet]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListQuestionnaireByUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userId = JwtConfigurator.GetTokenUserId(identity);

                var questionnaireList = await _questionnaireService.GetListQuestionnaireByUser(3);
                return Ok(questionnaireList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{questionnaireId}")]
        public async Task<IActionResult> Get(int questionnaireId)
        {
            try
            {
                var questionnaire = await _questionnaireService.GetQuestionnaire(questionnaireId);

                return Ok(questionnaire);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{questionnaireId}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int questionnaireId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userId = JwtConfigurator.GetTokenUserId(identity);

                var questionnaire = await _questionnaireService.FindQuestionnaire(questionnaireId, 3);
                if(questionnaire == null)
                {
                    return BadRequest(new { message = "Questionnaire not found" });
                }

                await _questionnaireService.DeleteQuestionnaire(questionnaire);
                return Ok(new {message = " The questionnare was deleted successfully" }); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListQuestionnaire")]
        [HttpGet]
        public async Task<IActionResult> GetListQuestionnaire()
        {
            try
            {
                var questionnaireList = await _questionnaireService.GetListQuestionnaire();

                return Ok(questionnaireList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
