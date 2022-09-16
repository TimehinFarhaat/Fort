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
        private readonly INumberVerificationService _numberVerificationService;
        private readonly IMailAddressVerification _mailAddressVerificationService;

        public ResponseController(IResponseService responseService, INumberVerificationService numberVerificationService,IMailAddressVerification mailAddressVerification)
        {
            _responseService = responseService;
            _numberVerificationService = numberVerificationService;
            _mailAddressVerificationService = mailAddressVerification;  
            
        }

        [HttpPost("SendSms")]
        public async Task<IActionResult> SendSms(string phoneNumber,string sendMessage)
        {
            var result = await _responseService.SendResponse(phoneNumber,sendMessage);
            if(result.Status) return Ok(result);
            return BadRequest(result);  
        }

        [HttpGet("VerifyNumber")]
        public async Task<IActionResult> VerifyNumber(string phoneNumber)
        {
            var result = await _numberVerificationService.VerifyMobileNumber(phoneNumber);
            if (result.Status) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet ("VefifyMailAddress")]
        public async Task<IActionResult> VefifyMailAddress(string email)
        {
            var result= await _mailAddressVerificationService.VerifyMailAddress(email);
            if(result.Status)return Ok(result);
            return BadRequest(result);
        }
    }
}
