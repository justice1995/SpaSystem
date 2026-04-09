using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Entities;

namespace BookingSystem.Application.Common.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> GetByIdAsync(Guid id);

        Task<List<Booking>> GetAllAsync();

        Task AddAsync(Booking booking);

        void Update(Booking booking);

        void Delete(Booking booking);
    }
}
