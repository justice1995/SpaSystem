using BookingSystem.Application.Common.Interfaces.Repositories;
using BookingSystem.Infrastructure.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _context;
        public BookingRepository(BookingDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Domain.Entities.Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public void Delete(Domain.Entities.Booking booking)
        {
            _context.Bookings.Remove(booking);
        }

        public async Task<List<Domain.Entities.Booking>> GetAllAsync()
        {
            return await _context.Bookings.Include(x => x.Items).ToListAsync();
        }

        public async Task<Domain.Entities.Booking> GetByIdAsync(Guid id)
        {
            return await _context.Bookings.Include(x => x.Items).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public void Update(Domain.Entities.Booking booking)
        {
            _context.Bookings.Update(booking);
        }
    }
}
