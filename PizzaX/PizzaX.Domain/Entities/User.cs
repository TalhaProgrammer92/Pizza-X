using PizzaX.Domain.Enums;

namespace PizzaX.Domain.Entities
{
    public class User : BaseEntity
    {
        // Attributes
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required UserRole Role { get; set; }
        public byte[]? ProfilePic { get; set; }
    }
}
