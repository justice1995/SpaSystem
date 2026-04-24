using BookingSystem.Application.Features.Services.DTOs;
using BookingSystem.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Services.Queries.GetById
{
    public class GetByIdQuery:IRequest<Result<ServiceDto?>>
    {
        public Guid Id { get; init; }
    }
}
