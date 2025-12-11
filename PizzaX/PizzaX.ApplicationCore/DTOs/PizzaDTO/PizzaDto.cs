using PizzaX.ApplicationCore.DTOs.BaseDTOs;

namespace PizzaX.ApplicationCore.DTOs.PizzaDTOs
{
    public class PizzaDto : BaseDto
    {
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; } = 0;
        public string Size { get; set; } = string.Empty;
        public string? Image { get; set; } = null;

        public int PizzaVarietyId { get; set; }
        public string? PizzaVarietyName { get; set; }
    }
}
