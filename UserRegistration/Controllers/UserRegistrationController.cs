using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        UserRegistrationBL _userRegistrationBL;

        public UserRegistrationController(UserRegistrationBL userRegistrationBL)
        {
            _userRegistrationBL = userRegistrationBL;

        }

        [HttpGet]
        public string Get()
        {
            return "Server Running....";
        }

        [HttpPost]
        [Route("register")]
        public IActionResult PostData(RegisterDTO user)
        {
            try
            {
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
