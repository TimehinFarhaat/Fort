using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseService _responseService;

        public ResponseController(IResponseService responseService)
        {
            _responseService = responseService;
        }

        [HttpPost("SendSms")]
        public async Task<IActionResult> SendSms(string phoneNumber)
        {
            var result = await _responseService.SendResponse(phoneNumber);
            if(result.Status) return Ok(result);
            return BadRequest(result);  
        }
    }
}
