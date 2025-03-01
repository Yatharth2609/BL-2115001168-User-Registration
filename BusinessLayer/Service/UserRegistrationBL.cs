using Microsoft.Extensions.Logging;
using ModelLayer.DTO;
using RepositoryLayer.Service;

namespace BusinessLayer.Service
{
    public class UserRegistrationBL
    {
        private readonly UserRegistrationRL _userRegistrationRL;
        private readonly ILogger<UserRegistrationBL> _logger;

        public UserRegistrationBL(ILogger<UserRegistrationBL> logger, UserRegistrationRL userRegistrationRL)
        {
            _logger = logger;
            _userRegistrationRL = userRegistrationRL;
        }

        public void RegisterUser(RegisterDTO user)
        {
            try
            {
                _logger.LogInformation("BusinessLayer: User is being Verified...");
                _userRegistrationRL.AddUser(user);
                _logger.LogInformation("BusinessLayer: User registration successful.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BusinessLayer: An error occurred while registering the user.");
                throw;
            }
        }
    }
}
