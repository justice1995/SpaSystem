using Booking.Application.Features.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces.Queries
{
    public interface IServiceQuery
    {
        Task<ServiceDto?> GetByIdAsync(Guid id);
        Task<List<ServiceDto>> GetAllAsync();
    }
}
