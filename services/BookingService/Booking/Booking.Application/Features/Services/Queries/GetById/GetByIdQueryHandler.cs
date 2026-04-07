using Booking.Application.Common.Interfaces.Queries;
using Booking.Application.Features.Services.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Services.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ServiceDto?>
    {
        private readonly IServiceQuery _serviceQuery;
        public GetByIdQueryHandler(IServiceQuery serviceQuery)
        {
            _serviceQuery = serviceQuery;
        }

        public async Task<ServiceDto?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var service= await _serviceQuery.GetByIdAsync(request.Id);
            if (service == null)
                return null;
            return new ServiceDto
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price,
                Duration = service.Duration
            };  
        }
    }
}
