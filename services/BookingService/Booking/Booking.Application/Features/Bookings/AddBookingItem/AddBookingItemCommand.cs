using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.AddBookingItem
{
    public class AddBookingItemCommand: IRequest<bool>
    {
        public Guid BookingId { get; set; }
        public List<AddBookingItemDto> Items { get; init; }
    }
}
