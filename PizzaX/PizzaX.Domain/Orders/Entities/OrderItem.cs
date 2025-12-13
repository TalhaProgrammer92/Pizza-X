using PizzaX.Domain.Common;
using PizzaX.Domain.Pizzas.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

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

        public PizzaCustomization? PizzaCustomization { get; private set; }

        public decimal TotalPrice
            => (UnitPrice * Quantity) + PizzaCustomization!.CalculateExtraCharges();

        // Constructors
        private OrderItem() { }

        public OrderItem(int pizzaId, int quantity, decimal unitPrice, PizzaCustomization? pizzaCustomization = null)
        {
            Guard.AgainstZeroOrLess(quantity, nameof(Quantity));
            Guard.AgainstNegative(unitPrice, nameof(UnitPrice));

            PizzaId = pizzaId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            PizzaCustomization = pizzaCustomization ?? PizzaCustomization.Create();
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
