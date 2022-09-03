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
        public IActionResult AnswerQuestion(CreateAnswerRequest request, int questionId,int doctorId)
        {
            var result = _answerService.CreateAnswer(request, questionId,doctorId);
            return Ok(result.Message);
        }


        [HttpDelete("DeleteAnswer")]
        public IActionResult DeleteAnswer( int answerId)
        {
            var result = _answerService.DeleteAnswer(answerId);
            return Ok(result);
        }



        [HttpGet("GetAnswersByDoctorId")]
        public IActionResult GetAnswer(int doctorId)
        {
             var result = _answerService.GetDoctorAnswers(doctorId);
            return Ok(result);
        }


        [HttpGet("GetAnswersToQuestion")]
        public IActionResult GetAnswersToQuestion(int questionId)
        {
            var result = _answerService.GetAnswersToQuestion(questionId);
            return Ok(result);
        }



    }
}
