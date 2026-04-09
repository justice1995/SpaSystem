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

namespace BookingSystem.Infrastructure.Persistence.Repositories
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
            await _context.Customers.AddAsync(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<List<Customer?>> GetAllAsync()
        {
            var entities = await _context.Customers
                .AsNoTracking()
                .ToListAsync();
            return entities;
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
