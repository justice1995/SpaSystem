using BookingSystem.Application.Features.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Common.Interfaces.Queries
{
    public interface IServiceQuery
    {
        Task<ServiceDto?> GetByIdAsync(Guid id);
        Task<List<ServiceDto>> GetAllAsync();
    }
}
