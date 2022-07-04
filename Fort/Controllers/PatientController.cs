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
        public IActionResult RegisterDoctor(CreatePatientRequest patientRequest)
        {
            var result = _patientService.AddPatient(patientRequest);
            return Ok(result);
        }


        [HttpGet("GetPatientDetailsById")]
        public IActionResult GetDoctorDetailsById(int id)
        {
            var result = _patientService.GetPatientById(id);
            return Ok(result);
        }


     


        [HttpDelete("DeletePatient")]
        public IActionResult DeleteDoctor(int id)
        {
            var result = _patientService.DeletePatient(id);
            return Ok(result.Message);
        }


        [HttpPatch("Updatepatient")]
        public IActionResult UpdateDoctor(UpdatePatientRequest updatePatientRequest, int id)
        {
            var result = _patientService.UpdatePatient(updatePatientRequest, id);
            return Ok(result);
        }
    }
}
