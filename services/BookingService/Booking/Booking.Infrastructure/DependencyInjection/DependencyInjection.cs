using BookingSystem.Application.Common.Interfaces;
using BookingSystem.Application.Common.Interfaces.Queries;
using BookingSystem.Application.Common.Interfaces.Repositories;
using BookingSystem.Infrastructure.Dapper;
using BookingSystem.Infrastructure.Persistence.DBContexts;
using BookingSystem.Infrastructure.Persistence.Repositories;
using BookingSystem.Infrastructure.Persistence.UnitOfWork;
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

namespace BookingSystem.Infrastructure.DependencyInjection
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

            //Command Repositories
            services.AddScoped<IServiceRepository,ServiceRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            //Query Repositories
            services.AddScoped<IServiceQuery, ServiceQuery>();
            services.AddScoped<ICustomerQuery, CustomerQuery>();

            //Unit Of Work 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
