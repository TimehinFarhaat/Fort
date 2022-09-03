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
        private readonly IWebHostEnvironment _webHostEnvironment;
        
    

        public   DoctorController(IDoctorService doctorService, IWebHostEnvironment webHostEnvironment)
        {
            _doctorService = doctorService;
            _webHostEnvironment = webHostEnvironment;
           
            
        }


        

        [HttpPost("RegisterDoctor")]
        public IActionResult RegisterDoctor([FromForm] CreateDoctorRequest doctorRequestmodel, int id)
        {
            var files = HttpContext.Request.Form;
            if(files.Count != 0)
            {
                string certificateDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "DoctorCertificate");
                Directory.CreateDirectory(certificateDirectory);
                foreach(var file in files.Files)
                {
                    FileInfo fileInfo = new FileInfo(file.FileName);
                    if(fileInfo.Extension.ToLower() != "pdf")
                    {
                        return BadRequest();
                    }
                    string doctorCertificate = "doctor" + Guid.NewGuid().ToString().Substring(2, 9) + $"{fileInfo.Extension}";
                    string fullPath = Path.Combine(certificateDirectory, doctorCertificate);
                    using(var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    doctorRequestmodel.Certificate = doctorCertificate;
                }
                var result = _doctorService.AddDoctor(doctorRequestmodel, id);
                return Ok(result); 
                
            }


            return BadRequest();
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

        [HttpGet("GetAllDoctors")]
        public IActionResult GetAllDoctors()
        {
            var result = _doctorService.GetDoctors();
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




        [HttpPatch("ApproveDoctor")]
        public IActionResult APProveDoctor(  int id)
        {
            var result = _doctorService.ApproveDoctor(id);
            return Ok(result);
        }



        [HttpPatch("DisapproveDoctor")]
        public IActionResult DisapproveDoctor(UpdateDoctorRequest doctorRequestmodel, int id)
        {
            var result = _doctorService.ApproveDoctor(id);
            return Ok(result);
        }


    }
}
