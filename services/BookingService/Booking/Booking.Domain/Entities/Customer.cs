using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Customer
    {
        public Customer(string name, string email, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            CreatedAt = DateTime.Now;
        }

        // Reconstruction constructor — used by persistence mapping to restore an existing entity
        public Customer(Guid id, string name, string email, string phone, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; private set; }
    
    }
}
