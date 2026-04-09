using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Services.Command.DeleteService
{
    public class DeleteServiceCommand:IRequest<bool>
    {
        public Guid Id { get; init; }
    }
}
