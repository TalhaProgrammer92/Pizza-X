using PizzaX.Domain.Common;
using PizzaX.Domain.Pizzas.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaX.Domain.Pizzas.Entities
{
    public sealed class Pizza : BaseEntity
    {
        // Attributes
        public byte[]? Image { get; private set; }

        [Required]
        public decimal Price { get; private set; }

        [Required]
        public PizzaSize Size { get; private set; }

        [Required]
        public int Amount { get; private set; }
        public string? Description { get; private set; }

        [Required]
        public int PizzaVarietyId { get; private set; }
        public PizzaVariety Variety { get; private set; }

        // Constructors
        private Pizza() { }

        private Pizza(decimal price, PizzaSize size, int amount, int varietyId, string? description, byte[]? image)
        {
            // Validation Check
            Guard.AgainstNegative(price, nameof(Price));
            Guard.AgainstZeroOrLess(amount, nameof(Amount));

            // Assigning values
            Price = price;
            Size = size;
            Amount = amount;
            PizzaVarietyId = varietyId;
            Description = description;
            Image = image;
        }

        // Method - Create a new pizza
        public static Pizza Create(decimal price, PizzaSize size, int amount, int varietyId, string? description = null, byte[]? image = null) 
            => new(price, size, amount, varietyId, description, image);

        // Method - Update Price
        public void UpdatePrice(decimal newPrice)
        {
            Guard.AgainstNegative(newPrice, nameof(Price));
            Price = newPrice;
            MarkUpdated();
        }

        // Method - Update Amount
        public void UpdateAmount(int newAmount)
        {
            Guard.AgainstZeroOrLess(newAmount, nameof(Amount));
            Amount = newAmount;
            MarkUpdated();
        }

        // Method - Update Description
        public void UpdateDescription(string? desc)
        {
            Description = desc;
            MarkUpdated();
        }

        // Method - Update Image
        public void UpdateImage(byte[]? img)
        {
            Image = img;
            MarkUpdated();
        }
    }
}
