using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class BookingItem
    {
        public Guid Id { get; private set; }

        public Guid BookingId { get; private set; }

        public Guid ServiceId { get; private set; }

        public string ServiceName { get; private set; }
        public decimal Price { get; private set; }

        public int Quantity { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public decimal TotalPrice => Price * Quantity;

        // EF constructor
        private BookingItem() { }

        public BookingItem(Guid serviceId,string serviceName, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(serviceName))
                throw new ArgumentException("Service name is required");

            if (price <= 0)
                throw new ArgumentException("Price must be greater than 0");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0");

            Id = Guid.NewGuid();
            ServiceName = serviceName;
            ServiceId = serviceId;
            Price = price;
            Quantity = quantity;
            CreatedAt = DateTime.Now;
        }

        // Business logic
        public void UpdateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0");

            Quantity = quantity;
        }

        public void UpdatePrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than 0");

            Price = price;
        }
    }
}
