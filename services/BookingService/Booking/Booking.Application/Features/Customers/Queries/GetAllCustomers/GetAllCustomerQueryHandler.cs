using BookingSystem.Application.Common.Interfaces.Queries;
using BookingSystem.Application.Features.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerDto>>
    {
        private readonly ICustomerQuery _customerQuery;
        public GetAllCustomerQueryHandler(ICustomerQuery customerQuery)
        {
            _customerQuery= customerQuery;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _customerQuery.GetAllAsync();
        }
    }
}
