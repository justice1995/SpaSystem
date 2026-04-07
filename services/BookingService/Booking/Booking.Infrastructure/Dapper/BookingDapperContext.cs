using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Dapper
{
    public interface IBookingDapperContext
    {
        IDbConnection CreateConnection();
    }
    public class BookingDapperContext : IBookingDapperContext
    {
        private readonly IConfiguration _configuration;
        public BookingDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }
    }
}
