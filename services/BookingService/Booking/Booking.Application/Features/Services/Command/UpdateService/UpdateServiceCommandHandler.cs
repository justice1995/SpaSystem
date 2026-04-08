using Booking.Application.Common.Interfaces;
using Booking.Application.Common.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Services.Command.UpdateService
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceRepository _serviceRepository;
        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository)
        {
            _unitOfWork= unitOfWork;
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);
            if (service == null)
                return false;
            service.Update(request.Name, request.Price, request.Duration);
            _serviceRepository.Update(service);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
