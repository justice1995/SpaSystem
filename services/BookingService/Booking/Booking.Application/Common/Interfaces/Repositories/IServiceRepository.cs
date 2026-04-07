using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces.Repositories
{
    public interface IServiceRepository
    {
        Task<Service?> GetByIdAsync(Guid id);
        Task<List<Service>> GetAllAsync();
        Task AddAsync(Service service);
        void Update(Service service);
        void Delete(Service service);
    }
}
