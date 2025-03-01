namespace ModelLayer.DTO
{
    public class RegisterDTO
    {
        public string firstName {  get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
 

        public override string ToString()
        {
            return "firstName: " + firstName + ";" + "lastName: " + lastName + ";" + "email: " + email;
        }

    }
}
