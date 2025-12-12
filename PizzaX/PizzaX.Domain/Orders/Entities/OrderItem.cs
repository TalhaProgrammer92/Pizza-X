using PizzaX.Domain.Common;
using System.Diagnostics.Metrics;

namespace PizzaX.Domain.Orders.Entities
{
    public sealed class OrderItem
    {
        // Attributes
        public int PizzaId { get; private set; }
        public int Quantity { get; private set; } = 0;
        public decimal UnitPrice { get; private set; }

        public decimal TotalPrice => Quantity * UnitPrice;

        // Constructors
        private OrderItem() { }

        public OrderItem(int pizzaId, int quantity, decimal unitPrice)
        {
            Guard.AgainstZeroOrLess(quantity, nameof(Quantity));
            Guard.AgainstNegative(unitPrice, nameof(UnitPrice));

            PizzaId = pizzaId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        // Method - Increase quantity
        public void IncreaseQuantity(int amount = 1)
        {
            Guard.AgainstZeroOrLess(amount, nameof(amount));
            Quantity += amount;
        }

        // Method - Decrease quantity
        public void DecreaseQuantity(int amount = 1)
        {
            Guard.AgainstZeroOrLess(amount, nameof(amount));

            if (Quantity - amount <= 0)
                throw new DomainException("Quantity cannot go below 1.");

            Quantity -= amount;
        }
    }
}
