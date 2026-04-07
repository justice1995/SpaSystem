using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }
        //public Customer Customer { get; private set; }

        public DateTime BookingDate { get; private set; }

        public decimal TotalAmount { get; private set; }

        public string Status { get; private set; }


    }
}
