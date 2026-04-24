using BookingSystem.Application.Common.Interfaces.Queries;
using BookingSystem.Application.Features.Services.DTOs;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Services.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Result<ServiceDto?>>
    {
        private readonly IServiceQuery _serviceQuery;
        public GetByIdQueryHandler(IServiceQuery serviceQuery)
        {
            _serviceQuery = serviceQuery;
        }

        public async Task<Result<ServiceDto?>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var service= await _serviceQuery.GetByIdAsync(request.Id);
            if (service == null)
                return Result<ServiceDto?>.Failure(new Error(ErrorType.Notfound, "Service not found"));
            return Result<ServiceDto?>.Success(new ServiceDto
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price,
                Duration = service.Duration
            });
        }
    }
}
