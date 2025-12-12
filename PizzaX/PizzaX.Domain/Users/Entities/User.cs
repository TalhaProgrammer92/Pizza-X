using PizzaX.Domain.Common;
using PizzaX.Domain.Users.Enums;
using PizzaX.Domain.Users.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaX.Domain.Users.Entities
{
    public sealed class User : BaseEntity
    {
        // Attributes
        [Required]
        public string Username { get; private set; }

        [Required]
        public string Password { get; private set; }

        [Required]
        public Email Email { get; private set; }

        [Required]
        public UserRole Role { get; private set; }
        
        public byte[]? ProfilePic { get; private set; }

        // Constructors
        private User() { }

        private User(string username, string password, Email email, UserRole role)
        {
            // Validation Check
            Guard.AgainstNull(username, nameof(Username));
            Guard.AgainstNull(password, nameof(Password));

            // Assigning values
            Username = username;
            Password = password;
            Email = email;
            Role = role;
        }

        // Method - Create a new user
        public static User Create(string username, string password, Email email, UserRole role) 
            => new(username, password, email, role);

        // Method - Change password
        public void ChangePassword(string newPass)
        {
            Guard.AgainstNull(newPass, nameof(Password));
            Password = newPass;
            MarkUpdated();
        }

        // Method - Update profile picture
        public void UpdateProfilePic(byte[]? picture)
        {
            ProfilePic = picture;
            MarkUpdated();
        }

        // Method - Update role of the user
        public void UpdateRole(UserRole newRole)
        {
            Role = newRole;
            MarkUpdated();
        }
    }
}
