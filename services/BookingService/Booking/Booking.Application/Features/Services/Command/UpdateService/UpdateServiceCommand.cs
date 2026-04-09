using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Services.Command.UpdateService
{
    public class UpdateServiceCommand:IRequest<bool>
    {
        public UpdateServiceCommand(Guid id, string name, decimal price, int duration) {
            Id = id;
            Name = name;
            Price = price;
            Duration = duration;
        }
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public int Duration { get; init; }
    }
}
