namespace PizzaX.ApplicationCore.DTOs.BaseDTOs
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
