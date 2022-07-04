using Fort.DTOs;
using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("RegisterAdmin")]
        public IActionResult RegisterAdmin(CreateAdminRequest adminRequestmodel, int id)
        {
            var result = _adminService.AddAdmin(adminRequestmodel, id);
            return Ok(result);
        }
         
        [HttpDelete("DeleteAdmin")]
        public IActionResult DeleteAdmin(string email)
        {
            var result = _adminService.DeleteAdmin(email);
            return Ok(result);
        }


        [HttpGet("GetAdminDetailsById")]
        public IActionResult GetAdminDetails(int id)
        {
            var result = _adminService.GetAdminById(id);
            return Ok(result);
        }


        [HttpGet("GetAdminDetailsByEmail")]
        public IActionResult GetAdminDetails(string email)
        {
            var result = _adminService.GetAdminByEmail(email);
            return Ok(result);
        }


        [HttpGet("GetApproveDoctor")]
        public IActionResult GetApproveDoctor(string email)
        {
            var result = _adminService.ApproveDoctor(email);
            return Ok(result);
        }

        [HttpGet("GetDisApproveDoctor")]
        public IActionResult GetDisApproveDoctor(string email)
        {
            var result = _adminService.DisapproveDoctor(email);
            return Ok(result);
        }



    }
}
