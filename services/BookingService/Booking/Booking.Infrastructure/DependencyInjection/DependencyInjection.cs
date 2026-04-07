using Booking.Application.Common.Interfaces;
using Booking.Application.Common.Interfaces.Queries;
using Booking.Application.Common.Interfaces.Repositories;
using Booking.Infrastructure.Dapper;
using Booking.Infrastructure.Persistence.DBContexts;
using Booking.Infrastructure.Persistence.Repositories;
using Booking.Infrastructure.Persistence.UnitOfWork;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //EF Core connection
            services.AddDbContext<BookingDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // Dapper connection
            //services.AddScoped<IDbConnection>(sp =>
            //    new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBookingDapperContext, BookingDapperContext>();

            // Repositories
            services.AddScoped<IServiceRepository,ServiceRepository>();

            //Query Repositories
            services.AddScoped<IServiceQuery, ServiceQuery>();

            //Unit Of Work 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
