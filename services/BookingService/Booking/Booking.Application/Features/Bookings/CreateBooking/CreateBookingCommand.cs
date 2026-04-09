using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.CreateBooking
{
    public class CreateBookingCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; init; }
        public List<CreateBookingItemDto> Items { get; init; }
    }

    public record CreateBookingItemDto(
            Guid ServiceId,
            string ServiceName,
            decimal Price,
            int Quantity
        );
}
