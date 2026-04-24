using BookingSystem.Application.Common.Interfaces;
using BookingSystem.Application.Common.Interfaces.Repositories;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Services.Command.UpdateService
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceRepository _serviceRepository;
        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
        }

        public async Task<Result<bool>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);
            if (service == null)
                return Result<bool>.Failure(new Error(ErrorType.Notfound, "Service Not Exists"));
            service.Update(request.Name, request.Price, request.Duration);
            _serviceRepository.Update(service);
            await _unitOfWork.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
    }
}
