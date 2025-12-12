using System.ComponentModel.DataAnnotations;

namespace PizzaX.Domain.Common
{
    public abstract class BaseEntity
    {
        // Attributes
        [Key]
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; }

        public void MarkUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
