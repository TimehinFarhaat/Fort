using Fort.DTOs;
using Fort.Implementation.Service;
using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      
        private readonly IUserService _userService;
        private readonly IAuthentication _authentication;

        public UserController( IUserService userService, IAuthentication authentication)
        {
            
            _userService = userService;
            _authentication = authentication;
        }

        [HttpPost("Login")]
        public  IActionResult Login([FromBody] LoginUserRequest requestmodel)
        {
            var result = _userService.LogIn(requestmodel);
            if (result.Status == false) return BadRequest(result);
           
            var logInResponseModel = new LoginResponseModel
            {
                Status = result.Status,
                Message=result.Message,
                Data = result.Data,
                Token=  _authentication.GenerateToken(result.Data)
            };
            return Ok(logInResponseModel);
        }


        [HttpGet("GetUserDetails")]
        public IActionResult GetUserDetails(int id)
        {
            var result = _userService.GetUserById(id);
            if (result.Status == false) return BadRequest(result.Message);
            return Ok(result);
        }


        [HttpGet("GetUserDetailsByEmail")]
        public IActionResult GetUserDetailsByEmail(string email)
        {
            var result = _userService.GetUserByEmail(email);
            if (result.Status == false) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result.Status == false) return BadRequest(result.Message);
            return Ok(result);
        }


        [HttpGet("GetUserByRole")]
        public IActionResult GetUserByRole(string Role)
        {
            var result = _userService.GetUsersByRole(Role);
            if (result.Status == false) return BadRequest(result);
            return Ok(result);
        }


        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var result = _userService.GetUsers();
            if (result.Status == false) return BadRequest(result);
            return Ok(result);
        }





    }
}
