using Fort.DTOs;
using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


      //  [Authorize(Roles = "Admin")]
        [HttpPost("AddRole")]
        public IActionResult AddRole(CreateRoleRequest roleRequestmodel)
        {
            var result = _roleService.AddRole(roleRequestmodel);
            return Ok(result);
        }



       // [Authorize(Roles="Admin")]
        [HttpDelete("DeleteRole")]
        public IActionResult DeleteRole(int id)
        {
            var result = _roleService.DeleteRole(id);
            return Ok(result);
        }


       // [Authorize(Roles = "Admin")]
        [HttpPatch("UpdateRole")]
        public IActionResult UpdateRole(UpdateRoleRequest updateRole,int id)
        {
            var result = _roleService.UpdateRole(updateRole,id);
            return Ok(result);
        }

       // [Authorize(Roles = "Admin")]
        [HttpGet("GetRoleDetailsById")]
        public IActionResult GetRoleDetailsById(int id)
        {
            var result = _roleService.GetRole(id);
            return Ok(result);
        }

      
        [HttpGet("GetSelectedRoles")]
        public IActionResult GetSelectedRoles(IList<int>id)
        {
            var result = _roleService.GetSelectedRoles(id);
            return Ok(result.Message);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var result = _roleService.GetRoles();
            return Ok(result);
        }
    }
}
