using Fort.DTOs;
using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
       
        [HttpPost("AskQuestion")]
        public IActionResult AskQuestion([FromBody] CreateQuestionRequest request, int id)
        {
            var result = _questionService.CreateQuestion(request,id);
            return Ok(result);
        }


        [HttpGet("GetUserQuestions")]
        public IActionResult GetUserQuestions(int id)
        {
            var result = _questionService.GetQuestionsByUser(id);
            if (result.Status == false) return BadRequest(result);
            return Ok(result);
        }


        [HttpDelete("DeleteQuestion")]
        public IActionResult DeleteQuestion(int id)
        {
            var result = _questionService.DeleteQuestion(id);
            if (result.Status == false) return BadRequest(result.Message);
            return Ok(result);
        }



        [HttpGet("GetQuestions")]
        public IActionResult GetQuestions()
        {
            var result = _questionService.GetQuestions();
            if (result.Status == false) return BadRequest(result);
            return Ok(result);
        }




        [HttpGet("GetQuestionsById")]
        public IActionResult GetQuestionById(int id)
        {
            var result = _questionService.GetQuestionById(id);
            if (result.Status == false) return BadRequest(result);
            return Ok(result);
        }
    }
}
