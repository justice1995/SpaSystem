using BookingSystem.Application.Common.Interfaces.Queries;
using BookingSystem.Application.Features.Customers.DTOs;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Dapper
{
    public class CustomerQuery : ICustomerQuery
    {
        private readonly IBookingDapperContext _context;

        public CustomerQuery(IBookingDapperContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var sql = @"
            SELECT Id, Name, Email, Phone, CreatedAt
            FROM Customers
            ";
            var result = await connection.QueryAsync<CustomerDto>(sql);
            return result.ToList();
        }

        public async Task<CustomerDto?> GetByIdAsync(Guid id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
            SELECT Id, Name, Email, Phone, CreatedAt
            FROM Customers
            WHERE Id = @Id
            ";
            return await connection.QueryFirstOrDefaultAsync<CustomerDto>(sql, new { Id = id });
        }
    }
}
