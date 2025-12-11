namespace PizzaX.Domain.Entities
{
    public class PizzaVariety : BaseEntity
    {
        // Attributes
        public required string Name { get; set; }

        public ICollection<Pizza> Pizzas { get; set; }
    }
}
