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
    public class AnswerQuestionnaireController : ControllerBase
    {
        private readonly IAnswerQuestionnaireService _answerQuestionnaireService;

        public AnswerQuestionnaireController(IAnswerQuestionnaireService answerQuestionnaireService)
        {
            _answerQuestionnaireService = answerQuestionnaireService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnswerQuestionnaire answerQuestionnaire)
        {
            try
            {
                await _answerQuestionnaireService.SaveAnswerQuestionnaire(answerQuestionnaire);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{questionnaireId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(int questionnaireId)
        {
            try
            {
                var indentity = HttpContext.User.Identity as ClaimsIdentity;
                int userId = JwtConfigurator.GetTokenUserId(indentity);

                var listAnswerQuestionnaire = await _answerQuestionnaireService.ListAnswerQuestionnaire(questionnaireId, userId);

                if (listAnswerQuestionnaire == null)
                {
                    return BadRequest(new { message = "Error finding the answer list" });
                }

                return Ok(listAnswerQuestionnaire);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var indentity = HttpContext.User.Identity as ClaimsIdentity;
                int userId = JwtConfigurator.GetTokenUserId(indentity);

                //Creating a method to obtain the answer of the questionnaire
                var answerQuestionnaire = await _answerQuestionnaireService.FindAnswerQuestionnaire(id, userId);
                
                if(answerQuestionnaire == null)
                {
                    return BadRequest(new { message = "Error when searching for the answer of the questionnaire" });
                }

                await _answerQuestionnaireService.DeleteAnwserQuestionnaire(answerQuestionnaire);

                return Ok(new { message = "The response to the questionnaire was deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
