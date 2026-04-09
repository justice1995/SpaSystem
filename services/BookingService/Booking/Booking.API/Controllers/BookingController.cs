using BookingSystem.Application.Features.Bookings.AddBookingItem;
using BookingSystem.Application.Features.Bookings.CreateBooking;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{bookingId}/items")]
        public async Task<IActionResult> AddBookingItem(Guid bookingId, [FromBody] AddBookingItemCommand command)
        {
            command.BookingId = bookingId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
