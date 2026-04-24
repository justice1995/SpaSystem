using BookingSystem.Application.Common.Interfaces.Queries;
using BookingSystem.Application.DTOs;
using BookingSystem.Application.Features.Customers.DTOs;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Dapper
{
    public class SalaryQuery : ISalaryQuery
    {
        private readonly IBookingDapperContext _context;
        public SalaryQuery(IBookingDapperContext context)
        {
            _context = context;
        }

        public async Task<List<SalaryDataDto>> GetListEmployeeAsync()
        {
            using var connection = _context.CreateConnection();
            var sql = @"
            SELECT *
            FROM Employees
            ";
            var result = await connection.QueryAsync<SalaryDataDto>(sql);
            return result.ToList();
        }
    }
}
