using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        ILogger<UserRegistrationController> _logger;
        UserRegistrationBL _userRegistrationBL;

        public UserRegistrationController(ILogger<UserRegistrationController> logger, UserRegistrationBL userRegistrationBL)
        {
            _logger = logger; 
            _userRegistrationBL = userRegistrationBL;

        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Controller: Server is Starting Up...");
            return Ok("Server Running....");
        }


        [HttpPost]
        [Route("register")]
        public IActionResult PostData(RegisterDTO user)
        {
            try
            {
                _logger.LogInformation("Controller: Registering the User...");
                _userRegistrationBL.RegisterUser(user);
                return Ok(new ResponseModel<RegisterDTO> { Success = true, Message = "Registered Succesfully.", Data = user });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<string> { Success = false, Message = "Registered Failed.", Data = ex.Message });
            }
        }


    }
}
