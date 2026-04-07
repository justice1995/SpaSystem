using Booking.Application.Common.Interfaces.Repositories;
using Booking.Domain.Entities;
using Booking.Infrastructure.Persistence.DBContexts;
using Booking.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly BookingDbContext _context;
        public ServiceRepository(BookingDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Service service)
        {
            var entity = service.ToPersistence();
            await _context.Services.AddAsync(entity);
        }

        public void Delete(Service service)
        {
            var entity = service.ToPersistence();
            _context.Services.Remove(entity);
        }

        public async Task<List<Service>> GetAllAsync()
        {
            var entities = await _context.Services
            .AsNoTracking()
            .ToListAsync();
            return entities.Select(x => x.ToDomain()).ToList();
        }

        public async Task<Service?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Services
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            return entity?.ToDomain();
        }

        public void Update(Service service)
        {
            var entity = service.ToPersistence();
            _context.Services.Update(entity);
        }
    }
}
