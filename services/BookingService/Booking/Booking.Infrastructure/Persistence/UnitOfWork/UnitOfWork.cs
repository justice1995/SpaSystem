using Booking.Application.Common.Interfaces;
using Booking.Infrastructure.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingDbContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(BookingDbContext context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction?.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _transaction?.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
