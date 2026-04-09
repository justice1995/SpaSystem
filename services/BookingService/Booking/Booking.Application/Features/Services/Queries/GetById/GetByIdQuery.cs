using BookingSystem.Application.Features.Services.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Services.Queries.GetById
{
    public class GetByIdQuery:IRequest<ServiceDto?>
    {
        public Guid Id { get; init; }
    }
}
