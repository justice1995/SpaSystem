using BookingSystem.Domain.Common;
using MediatR;
using System;

namespace BookingSystem.Application.Features.Customers.Command.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
    }
}