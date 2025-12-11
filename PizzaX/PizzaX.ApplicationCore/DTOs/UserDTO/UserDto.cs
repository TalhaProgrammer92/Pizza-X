using PizzaX.ApplicationCore.DTOs.BaseDTOs;

namespace PizzaX.ApplicationCore.DTOs.UserDTO
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? ProfilePic { get; set; } = null;
    }
}
