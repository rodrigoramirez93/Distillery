namespace BusinessLogic.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            UserName = "";
            Password = "";
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
