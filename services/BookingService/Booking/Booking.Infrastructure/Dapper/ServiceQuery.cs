using Booking.Application.Common.Interfaces.Queries;
using Booking.Application.Features.Services.DTOs;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Dapper
{
    public class ServiceQuery : IServiceQuery
    {
        private readonly IBookingDapperContext _context;
        public ServiceQuery(IBookingDapperContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceDto>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var sql = @"
            SELECT Id, Name, Price, Duration
            FROM Services
            ";
            var result = await connection.QueryAsync<ServiceDto>(sql);
            return result.ToList();
        }

        public async Task<ServiceDto?> GetByIdAsync(Guid id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
            SELECT Id, Name, Price, Duration
            FROM Services
            WHERE Id = @Id
            ";
            return await connection.QueryFirstOrDefaultAsync<ServiceDto>(sql, new { Id = id });
        }
    }
}
