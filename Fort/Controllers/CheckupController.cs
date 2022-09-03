using Fort.DTOs;
using Fort.Implementation.Service;
using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckupController : ControllerBase
    {
        private readonly ICheckupService _checkupService;
        private readonly IAuthentication _authentication;

        public CheckupController(ICheckupService checkupService, IAuthentication authentication)
        {
            _checkupService = checkupService;
            _authentication = authentication;
        }

        [HttpPost("CreateDiagnosis")]
        public IActionResult CreateDiagnosis([FromBody]CreateCheckupRequest requestmodel, int id)
        {
            var result = _checkupService.CreateCheckup(requestmodel, id);
            return Ok(result);
        }

        [HttpDelete("DeleteDiagnose")]
        public IActionResult DeleteDiagnose(int id)
        {
            var result = _checkupService.DeleteCheckup( id);
            if (result.Status == false) return BadRequest(result.Message);
            return Ok(result);
        }



        [HttpGet("GetDiagnoseByUser")]
        public IActionResult GetDiagnoseByUser(int id)
        {
            var result = _checkupService.GetCheckUpByPatientId(id);
            return Ok(result);
        }


        [HttpGet("GetPreviousDiagnose")]
        public IActionResult GetPreviousDiagnose(int Id)
        {
            var result = _checkupService.GetPreviouscheckup(Id);
            return Ok(result);
        }


       
    }
}
