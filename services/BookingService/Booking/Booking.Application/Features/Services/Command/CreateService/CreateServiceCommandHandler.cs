using BookingSystem.Application.Common.Interfaces;
using BookingSystem.Application.Common.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Services.Command.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Guid>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateServiceCommandHandler(IServiceRepository serviceRepository,
            IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Domain.Entities.Service(request.Name, request.Price, request.Duration);
            await _serviceRepository.AddAsync(service);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return service.Id;
        }
    }
}
