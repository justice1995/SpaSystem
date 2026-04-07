using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking.Domain.Entities.Booking> GetByIdAsync(Guid id);

        Task<List<Booking.Domain.Entities.Booking>> GetAllAsync();

        Task AddAsync(Booking.Domain.Entities.Booking booking);

        void Update(Booking.Domain.Entities.Booking booking);

        void Delete(Booking.Domain.Entities.Booking booking);
    }
}
