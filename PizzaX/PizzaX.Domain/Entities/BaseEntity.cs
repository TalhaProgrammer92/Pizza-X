using System.ComponentModel.DataAnnotations;

namespace PizzaX.Domain.Entities
{
    public class BaseEntity
    {
        // Attributes
        [Key]
        public int Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
