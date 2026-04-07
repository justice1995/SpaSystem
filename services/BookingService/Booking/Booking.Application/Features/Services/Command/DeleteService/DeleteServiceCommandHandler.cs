using Booking.Application.Common.Interfaces;
using Booking.Application.Common.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Services.Command.DeleteService
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceRepository _serviceRepository;
        public DeleteServiceCommandHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
        }
        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service= await _serviceRepository.GetByIdAsync(request.Id);
            if (service == null)
                return false;
            _serviceRepository.Delete(service);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
