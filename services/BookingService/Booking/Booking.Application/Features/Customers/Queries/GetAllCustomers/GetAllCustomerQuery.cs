using Booking.Application.Features.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomerQuery: IRequest<List<CustomerDto>>
    {
    }
}
