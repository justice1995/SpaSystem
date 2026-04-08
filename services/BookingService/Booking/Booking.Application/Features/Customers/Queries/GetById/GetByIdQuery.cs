using Booking.Application.Features.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Customers.Queries.GetById
{
    public class GetByIdQuery:IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}
