using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer?>> GetAllAsync();
        Task<Customer?> GetByIdAsync(Guid id);
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
