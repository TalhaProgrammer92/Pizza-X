using PizzaX.Domain.Common;

namespace PizzaX.Domain.Orders.ValueObjects
{
    public sealed class DeliveryInfo
    {
        // Attributes
        public string CustomerName { get; }
        public string AddressLine { get; }
        public string City { get; }
        public string Phone { get; }

        // Constructor
        private DeliveryInfo(string customerName, string addressLine, string city, string phone)
        {
            Guard.AgainstNull(customerName, nameof(CustomerName));
            Guard.AgainstNull(addressLine, nameof(AddressLine));
            Guard.AgainstNull(city, nameof(City));
            Guard.AgainstNull(phone, nameof(Phone));

            CustomerName = customerName;
            AddressLine = addressLine;
            City = city;
            Phone = phone;
        }

        // Method - Create an delivery info for the customer
        public static DeliveryInfo Create(string customerName, string address, string city, string phone)
            => new(customerName, address, city, phone);
    }
}
