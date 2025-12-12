using PizzaX.Domain.Common;

namespace PizzaX.Domain.Orders.ValueObjects
{
    public sealed class OrderNumber
    {
        // Attribute
        public string Value { get; }

        // Constructor
        private OrderNumber(string value)
        {
            Guard.AgainstNull(value, nameof(OrderNumber));
            Value = value;
        }

        // Method - Create a number for the order
        public static OrderNumber Create()
        {
            var id = Guid.NewGuid().ToString("N")[..8].ToUpper();
            return new OrderNumber($"PZX-{id}");
        }

        // Method - String conversion
        public override string ToString() => Value;
    }
}
