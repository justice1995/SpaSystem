using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Duration { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Service() { } // EF

        public Service(string name, decimal price, int duration)
        {
            if (price < 0)
                throw new ArgumentException("Price must be >= 0");
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Duration = duration;
            CreatedAt = DateTime.UtcNow;
        }

        public Service(Guid id, string name, decimal price, int duration, DateTime createdAt)
        {
            if (price < 0)
                throw new ArgumentException("Price must be >= 0");
            Id = id;
            Name = name;
            Price = price;
            Duration = duration;
            CreatedAt = createdAt;
        }

        public void Update(string name, decimal price, int duration)
        {
            if (price < 0)
                throw new ArgumentException("Price must be >= 0");
            Name = name;
            Price = price;
            Duration = duration;
        }
    }
}
