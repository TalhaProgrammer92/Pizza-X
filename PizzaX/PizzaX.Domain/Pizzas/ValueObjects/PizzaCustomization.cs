using PizzaX.Domain.Common;
using System.Numerics;

namespace PizzaX.Domain.Pizzas.ValueObjects
{
    public sealed class PizzaCustomization
    {
        // Attributes
        public bool ExtraCheese { get; }
        public bool ExtraSauce { get; }
        public bool ExtraToppings { get; }
        public int NoOfCustomizedPizzas { get; }

        // Business rule: If nothing is selected, customization does not exist
        public bool Exists => ExtraCheese || ExtraSauce || ExtraToppings;

        // Constructor
        private PizzaCustomization(bool extraCheese, bool extraSauce, bool extraToppings, int noOfCustomizedPizzas)
        {
            ExtraCheese = extraCheese;
            ExtraSauce = extraSauce;
            ExtraToppings = extraToppings;
            NoOfCustomizedPizzas = noOfCustomizedPizzas;
        }

        // Method – Creates pizza customization
        public static PizzaCustomization Create(bool extraCheese = false, bool extraSauce = false, bool extraToppings = false, int noOfCustomizedPizzas = 0, int totalPizzas = 0)
        {
            Guard.AgainstRange(0, totalPizzas, noOfCustomizedPizzas, nameof(NoOfCustomizedPizzas));

            return new(extraCheese, extraSauce, extraToppings, noOfCustomizedPizzas);
        }

        // Method - Calculate charges on customization
        public decimal CalculateExtraCharges()
        {
            decimal total = 0;

            if (ExtraCheese)
                total += 80;

            if (ExtraSauce)
                total += 50;

            if (ExtraToppings)
                total += 70;

            return total * NoOfCustomizedPizzas;
        }
    }
}
