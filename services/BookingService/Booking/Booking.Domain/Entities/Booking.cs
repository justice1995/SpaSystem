using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; private set; }
        public string BookingCode { get; private set; }

        public Guid CustomerId { get; private set; }

        public DateTime BookingDate { get; private set; }

        public decimal TotalAmount { get; private set; }

        public BookingStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private readonly List<BookingItem> _items = new();
        public IReadOnlyCollection<BookingItem> Items => _items;

        private Booking() { } // EF

        public Booking(Guid customerId)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            BookingDate = DateTime.Now;
            Status = BookingStatus.Pending;
            BookingCode= "abcd";
        }

        public void AddItem(Guid serviceId, string serviceName, decimal price, int quantity)
        {
            var item = new BookingItem(serviceId, serviceName, price, quantity);
            _items.Add(item);
            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            TotalAmount = _items.Sum(x => x.Price * x.Quantity);
        }

        public void Confirm()
        {
            if (!_items.Any())
                throw new Exception("Booking must have at least one item");

            Status = BookingStatus.Confirmed;
        }
    }
}
