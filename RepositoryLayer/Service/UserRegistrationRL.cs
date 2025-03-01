using Microsoft.Extensions.Logging;
using ModelLayer.DTO;


namespace RepositoryLayer.Service
{
    public class UserRegistrationRL
    {
        private readonly ILogger<UserRegistrationRL> _logger;
        private static List<RegisterDTO> users = new List<RegisterDTO>();

        public UserRegistrationRL(ILogger<UserRegistrationRL> logger)
        {
            _logger = logger;
        }

        public void AddUser(RegisterDTO user)
        {
            try
            {
                _logger.LogInformation("RepositoryLayer: Adding the User..");
                users.Add(user);
                _logger.LogInformation("RepositoryLayer: User added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RepositoryLayer: An error occurred while adding the user.");
                throw;
            }
        }
    }
}
