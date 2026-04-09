using BookingSystem.Application.Features.Services.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Services.Queries.GetAllServices
{
    public class GetAllServicesQuery:IRequest<List<ServiceDto>>
    {

    }
}
