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
        public IActionResult AnswerQuestion(CreateAnswerRequest request, [FromQuery]int questionId, [FromQuery] int doctorId)
        {
            var result = _answerService.CreateAnswer(request, questionId,doctorId);
           if(!result.Status) return BadRequest(result);
           return Ok(result);
        }


        [HttpDelete("DeleteAnswer")]
        public IActionResult DeleteAnswer( int answerId)
        {
            var result = _answerService.DeleteAnswer(answerId);
            return Ok(result);
        }

        


        [HttpGet("GetAnswersByDoctorId")]
        public IActionResult GetAnswersByDoctorId([FromQuery]int doctorId)
        {
             var result = _answerService.GetDoctorAnswers(doctorId);
            return Ok(result);
        }


        [HttpPost("RateAnswer/{id}")]
        public IActionResult RateAnswer([FromRoute]int id)
        {
            var result = _answerService.AddRating(id);
            return Ok(result);
        }


        [HttpPost("RemoveAnswerRate/{id}")]
        public IActionResult RemoveAnswerRate([FromRoute] int id)
        {
            var result = _answerService.AddRating(id);
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
