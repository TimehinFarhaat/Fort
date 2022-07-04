using Fort.DTOs;
using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost("AnswerQuestion")]
        public IActionResult AnswerQuestion(CreateAnswerRequest request, int questionId)
        {
            var result = _answerService.CreateAnswer(request, questionId);
            return Ok(result);
        }


        [HttpDelete("DeleteAnswer")]
        public IActionResult DeleteAnswer( int answerId)
        {
            var result = _answerService.DeleteAnswer(answerId);
            return Ok(result);
        }


        [HttpPost("AnswerQuestions")]
        public IActionResult AnswerQuestions([FromBody] CreateAnswerRequest request, [FromQuery]List<int> questionsId)
        {
            var result = _answerService.CreateAnswer(request, questionsId);
            return Ok(result);
        }
    }
}
