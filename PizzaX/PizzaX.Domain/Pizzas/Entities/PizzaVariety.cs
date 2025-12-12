using PizzaX.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PizzaX.Domain.Pizzas.Entities
{
    public sealed class PizzaVariety : BaseEntity
    {
        // Attributes
        [Required]
        public string Name { get; private set; }

        // Constructors
        private PizzaVariety() { }

        public PizzaVariety(string name)
        {
            Guard.AgainstNull(name, nameof(Name));
            Name = name;
        }

        // Method - Update name of the pizza variety
        public void Rename(string newName)
        {
            Guard.AgainstNull(newName, nameof(Name));
            Name = newName;
            MarkUpdated();
        }
    }
}
