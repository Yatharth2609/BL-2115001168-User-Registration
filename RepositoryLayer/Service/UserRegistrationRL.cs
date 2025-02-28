using ModelLayer.DTO;

namespace RepositoryLayer.Service
{
    public class UserRegistrationRL
    {
        private static List<RegisterDTO> users = new List<RegisterDTO>();

        public void AddUser(RegisterDTO user)
        {
            users.Add(user);
        }

    }
}
