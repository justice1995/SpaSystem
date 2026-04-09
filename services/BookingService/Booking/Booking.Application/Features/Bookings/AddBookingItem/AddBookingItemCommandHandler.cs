using BookingSystem.Application.Common.Interfaces;
using BookingSystem.Application.Common.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.AddBookingItem
{
    public class AddBookingItemCommandHandler : IRequestHandler<AddBookingItemCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddBookingItemCommandHandler(IBookingRepository bookingRepository, IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _bookingRepository = bookingRepository;
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddBookingItemCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(request.BookingId);
            foreach (var item in request.Items)
            {
                var service = await _serviceRepository.GetByIdAsync(item.ServiceId);
                booking.AddItem(item.ServiceId, service.Name, service.Price, item.Quantity);
            }
            _bookingRepository.Update(booking);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
