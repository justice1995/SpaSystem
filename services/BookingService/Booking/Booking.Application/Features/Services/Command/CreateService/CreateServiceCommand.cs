using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Services.Command.CreateService
{
    public record CreateServiceCommand:IRequest<Guid>
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
        public int Duration { get; init; }
        
    }
}
