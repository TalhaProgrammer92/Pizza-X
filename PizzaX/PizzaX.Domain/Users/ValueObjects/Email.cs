using PizzaX.Domain.Common;
using System.Text.RegularExpressions;

namespace PizzaX.Domain.Users.ValueObjects
{
    public sealed class Email
    {
        public string Value { get; }

        private Email(string value) => Value = value;

        public static Email Create(string value)
        {
            // Checking if email is null
            Guard.AgainstNull(value, nameof(Email));

            // Matching pattern of the email
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(value, pattern))
                throw new DomainException("Invalid email format.");

            return new Email(value);
        }

        public override string ToString() => Value;
    }
}
