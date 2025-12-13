using PizzaX.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PizzaX.Domain.Orders.Entities
{
    public sealed class OrderItem
    {
        // Attributes
        public int PizzaId { get; private set; }
        
        [Required]
        public int Quantity { get; private set; } = 0;

        [Required]
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
            Guard.AgainstNegative(Quantity - amount, nameof(Quantity));

            Quantity -= amount;
        }
    }
}
