namespace VoteMelhor.WebApi.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDto(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}