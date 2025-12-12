namespace PizzaX.Domain.Orders.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        Preparing = 2,
        Ready = 3,
        OutForDelivery = 4,
        Delivered = 5,
        Cancelled = 6
    }
}
