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
        public async Task<IActionResult> RegisterAdmin([FromForm] CreateAdminRequest adminRequestmodel)
        {
            var result = await _adminService.AddAdmin(adminRequestmodel);
            return Ok(result);
        }
         


        [HttpDelete("DeleteAdmin")]
        public IActionResult DeleteAdmin(int id)
        {
            var result = _adminService.DeleteAdmin(id);
            return Ok(result);
        }


        [HttpGet("GetAdminDetailsById")]
        public IActionResult GetAdminDetailsById(int id)
        {
            var result = _adminService.GetAdminById(id);
            return Ok(result);
        }

        [HttpGet("GetAllAdmins")]
        public IActionResult GetAllAdmins()
        {
            var result = _adminService.GetAdmins();
            return Ok(result);
        }


        [HttpPatch("UpdateAdmin")]
        public IActionResult UpdateAdmin([FromForm]UpdateAdminRequest adminRequestmodel, int id)
        {
            var result = _adminService.UpdateAdmin(adminRequestmodel, id);
            return Ok(result);
        }



        [HttpGet("GetAdminDetailsByEmail")]
        public IActionResult GetAdminDetails(string email)
        {
            var result = _adminService.GetAdminByEmail(email);
            return Ok(result);
        }
     }
}
