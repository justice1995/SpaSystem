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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookingDbContext _context;

        public CustomerRepository(BookingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            var entity = customer.ToPersistence();
            await _context.Customers.AddAsync(entity);
        }

        public void Delete(Customer customer)
        {
            var entity = customer.ToPersistence();
            _context.Customers.Remove(entity);
        }

        public async Task<List<Customer?>> GetAllAsync()
        {
            var entities = await _context.Customers
                .AsNoTracking()
                .ToListAsync();
            return entities.Select(x => x.ToDomain()).ToList<Customer?>();
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity?.ToDomain();
        }

        public void Update(Customer customer)
        {
            var entity = customer.ToPersistence();
            _context.Customers.Update(entity);
        }
    }
}
