using Fort.DTOs;
using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        
    

        public   DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
           
            
        }


        

        [HttpPost("RegisterDoctor")]
        public IActionResult RegisterDoctor(CreateDoctorRequest doctorRequestmodel, int id)
        {
            var result = _doctorService.AddDoctor(doctorRequestmodel,id);
            return Ok(result);
        }


        [HttpGet("GetDoctorDetailsById")]
        public IActionResult GetDoctorDetailsById(int id)
        {
            var result = _doctorService.GetDoctorById(id);
            return Ok(result);
        }


        [HttpGet("GetDoctorDetailsByEmail")]
        public IActionResult GetDoctorDetailsByEmail(string email)
        {
            var result = _doctorService.GetDoctor(email);
            return Ok(result);
        }


       [HttpDelete("DeleteDoctor")]
        public IActionResult DeleteDoctor(int id)
        {
            var result = _doctorService.DeleteDoctor(id);
            return Ok(result.Message);
        }


        [HttpPatch("UpdateDoctor")]
        public IActionResult UpdateDoctor(UpdateDoctorRequest doctorRequestmodel, int id)
        {
            var result = _doctorService.UpdateDoctor(doctorRequestmodel, id);
            return Ok(result);
        }
    }
}
