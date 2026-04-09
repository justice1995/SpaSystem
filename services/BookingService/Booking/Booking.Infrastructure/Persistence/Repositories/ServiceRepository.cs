using BookingSystem.Application.Common.Interfaces.Repositories;
using BookingSystem.Domain.Entities;
using BookingSystem.Infrastructure.Persistence.DBContexts;
using BookingSystem.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BookingSystem.Infrastructure.Persistence.Repositories
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
            await _context.Services.AddAsync(service);
        }

        public void Delete(Service service)
        {
            _context.Services.Remove(service);
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services.AsNoTracking().ToListAsync();
        }

        public async Task<Service?> GetByIdAsync(Guid id)
        {
            return await _context.Services.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id); 
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
        }
    }
}
