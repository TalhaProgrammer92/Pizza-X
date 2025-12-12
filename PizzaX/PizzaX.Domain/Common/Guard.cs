namespace PizzaX.Domain.Common
{
    public static class Guard
    {
        public static void AgainstNull(string value, string property)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException($"{property} cannot be empty.");
        }

        public static void AgainstNegative(decimal value, string property)
        {
            if (value < 0)
                throw new DomainException($"{property} cannot be negative.");
        }

        public static void AgainstZeroOrLess(int value, string property)
        {
            if (value <= 0)
                throw new DomainException($"{property} must be greater than zero.");
        }
    }
}
