using Fort.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class SymptomController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IUserService _userService;

        public SymptomController(IDoctorService doctorService, IUserService userService)
        {
            _doctorService = doctorService;
            _userService = userService;
        }
    }
}
