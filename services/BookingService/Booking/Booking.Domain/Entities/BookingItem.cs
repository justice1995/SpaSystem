using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class BookingItem
    {
        public Guid Id { get; private set; }

        public Guid BookingId { get; private set; }

        public string ProductName { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public decimal TotalPrice => Price * Quantity;

        // EF constructor
        private BookingItem() { }
        internal BookingItem(string productName, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name is required");

            if (price <= 0)
                throw new ArgumentException("Price must be greater than 0");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0");

            Id = Guid.NewGuid();
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        // Business logic
        internal void UpdateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0");

            Quantity = quantity;
        }

        internal void UpdatePrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than 0");

            Price = price;
        }
    }
}
