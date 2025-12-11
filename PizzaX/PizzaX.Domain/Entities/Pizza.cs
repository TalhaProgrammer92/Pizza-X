using PizzaX.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaX.Domain.Entities
{
    public class Pizza : BaseEntity
    {
        // Attributes
        public byte[]? Image { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public required decimal Price { get; set; }

        public required PizzaSize Size { get; set; }

        public required int Amount { get; set; }

        public string? description { get; set; }

        // Foriegn Key - Attributes
        public required int PizzaVarietyId { get; set; }
        public required PizzaVariety PizzaVariety { get; set; }
    }
}
