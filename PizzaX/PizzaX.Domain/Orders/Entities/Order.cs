using PizzaX.Domain.Common;
using PizzaX.Domain.Orders.Enums;
using PizzaX.Domain.Orders.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PizzaX.Domain.Orders.Entities
{
    public sealed class Order : BaseEntity
    {
        // Attributes
        private readonly List<OrderItem> _items = new();

        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        [Required]
        public OrderStatus Status { get; private set; }

        [Required]
        public PaymentStatus PaymentStatus { get; private set; }

        [Required]
        public PaymentMethod PaymentMethod { get; private set; }

        [Required]
        public decimal TotalPrice { get; private set; }

        [Required]
        public int UserId { get; private set; }

        [Required]
        public OrderNumber OrderNumber { get; private set; }

        [Required]
        public DeliveryInfo DeliveryInfo { get; private set; }

        // Constructors
        private Order() { }

        private Order(int userId, DeliveryInfo deliveryInfo, PaymentMethod paymentMethod)
        {
            UserId = userId;
            DeliveryInfo = deliveryInfo;
            PaymentMethod = paymentMethod;

            TotalPrice = 0;
            Status = OrderStatus.Pending;
            PaymentStatus = PaymentStatus.Unpaid;
            OrderNumber = OrderNumber.Create();
        }

        // Method - Create Order
        public static Order Create(int userId, DeliveryInfo deliveryInfo, PaymentMethod paymentMethod) 
            => new(userId, deliveryInfo, paymentMethod);

        /* ------------------------ */
        /*  Order Behavior (Rules)  */
        /* ------------------------ */

        // Method - Add Item
        public void AddItem(int pizzaId, int quantity, decimal price)
        {
            var item = new OrderItem(pizzaId, quantity, price);
            _items.Add(item);
            TotalPrice += item.TotalPrice;
            MarkUpdated();
        }

        // Method - Remove Item
        public void RemoveItem(OrderItem item)
        {
            if (!_items.Contains(item))
                throw new DomainException("Item does not belong to this order.");

            _items.Remove(item);
            TotalPrice -= item.TotalPrice;
            MarkUpdated();
        }

        /* -------------------- */
        /*  Status Transitions  */
        /* -------------------- */

        // Method - Mark as preparing
        public void MarkAsPreparing()
        {
            if (Status != OrderStatus.Pending)
                throw new DomainException("Only pending orders can be marked as preparing.");

            Status = OrderStatus.Preparing;
            MarkUpdated();
        }

        // Method - Mark as ready
        public void MarkAsReady()
        {
            if (Status != OrderStatus.Preparing)
                throw new DomainException("Only preparing orders can be marked ready.");

            Status = OrderStatus.Ready;
            MarkUpdated();
        }

        // Method - Mark as out for delivery
        public void MarkAsOutForDelivery()
        {
            if (Status != OrderStatus.Ready)
                throw new DomainException("Order must be ready before delivery.");

            Status = OrderStatus.OutForDelivery;
            MarkUpdated();
        }

        // Method - Mark as delivered
        public void MarkAsDelivered()
        {
            if (Status != OrderStatus.OutForDelivery)
                throw new DomainException("Order must be out for delivery before delivered.");

            Status = OrderStatus.Delivered;
            MarkUpdated();
        }

        // Method - Mark as cancelled
        public void Cancel()
        {
            if (Status == OrderStatus.Delivered)
                throw new DomainException("Delivered orders cannot be cancelled.");

            Status = OrderStatus.Cancelled;
            MarkUpdated();
        }

        /* ------------------ */
        /*  Payment Handling  */
        /* ------------------ */

        // Method - Mark as paid
        public void MarkPaymentAsPaid()
        {
            if (PaymentStatus == PaymentStatus.Paid)
                throw new DomainException("Payment already completed.");

            PaymentStatus = PaymentStatus.Paid;
            MarkUpdated();
        }

        // Method - Mark as failed
        public void MarkPaymentAsFailed()
        {
            PaymentStatus = PaymentStatus.Failed;
            MarkUpdated();
        }
    }
}
