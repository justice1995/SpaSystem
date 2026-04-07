using Booking.Application.Common.Interfaces.Queries;
using Booking.Application.Features.Services.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Services.Queries.GetAllServices
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, List<ServiceDto>>
    {
        private readonly IServiceQuery _serviceQuery;
        public GetAllServicesQueryHandler(IServiceQuery serviceQuery)
        {
            _serviceQuery = serviceQuery;
        }

        public async Task<List<ServiceDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceQuery.GetAllAsync();
            return services.Select(x=> new ServiceDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Duration = x.Duration
            }).ToList();
        }
    }
}
