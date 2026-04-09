using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.AddBookingItem
{
    public class AddBookingItemDto
    {
        public Guid ServiceId { get; set; }
        public int Quantity { get; set; }
    }
}
