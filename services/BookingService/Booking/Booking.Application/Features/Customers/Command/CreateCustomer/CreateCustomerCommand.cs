using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Customers.Command.CreateCustomer
{
    public record CreateCustomerCommand : IRequest<Guid>
    {
        public CreateCustomerCommand(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public string Name { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
    }
}   
