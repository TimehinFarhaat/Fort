using Fort.DTOs;
using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;



        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;


        }




        [HttpPost("RegisterPatient")]
        public async Task<IActionResult> Registerpatient([FromForm]CreatePatientRequest patientRequest)
        {
            var result = await _patientService.AddPatient(patientRequest);
            return Ok(result);
        }


        [HttpGet("GetPatientDetailsById")]
        public IActionResult GetDoctorDetailsById(int id)
        {
            var result = _patientService.GetPatientById(id);
            return Ok(result);
        }

        [HttpGet("GetPatientDetailsByEmail")]
        public IActionResult GetDoctorDetailsByEmail(string email)
        {
            var result = _patientService.GetPatientByEmail(email);
            return Ok(result);
        }

        [HttpGet("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            var result = _patientService.GetPatients();
            return Ok(result);
        }



        [HttpDelete("DeletePatient")]
        public IActionResult DeletePatient(int id)
        {
            var result = _patientService.DeletePatient(id);
            return Ok(result);
        }


        [HttpPatch("Updatepatient")]
        public IActionResult UpdateDoctor([FromForm] UpdatePatientRequest updatePatientRequest, int id)
        {
            var result = _patientService.UpdatePatient(updatePatientRequest, id);
            return Ok(result);
        }
    }
}
