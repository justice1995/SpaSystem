using Booking.Application.Common.Interfaces.Queries;
using Booking.Application.Features.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Customers.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CustomerDto>
    {
        private readonly ICustomerQuery _customerQuery;
        public GetByIdQueryHandler(ICustomerQuery customerQuery)
        {
            _customerQuery = customerQuery;
        }

        public async Task<CustomerDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerQuery.GetByIdAsync(request.Id);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }
    }
}
