using Auth.Domain.Interfaces;
using Auth.Infrastructure.Authentication;
using Auth.Infrastructure.Caching;
using Auth.Infrastructure.Persistence.DBContexts;
using Auth.Infrastructure.Persistence.UnitOfWork;
using Auth.Infrastructure.Repositories;
using Auth.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Auth.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //EF Core connection
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // Dapper connection
            //services.AddScoped<IBookingDapperContext, BookingDapperContext>();

            //Command Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //Query Repositories

            //Security Services
            services.AddScoped <IPasswordHasher, PasswordHasher>();

            //Unit Of Work 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = "localhost:6379";
            //    options.InstanceName = "AuthApi:";
            //});

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            //comment
            //services.AddSingleton<IConnectionMultiplexer>(
            //ConnectionMultiplexer.Connect("localhost:6379"));

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IRefreshTokenStore, RedisRefreshTokenStore>();

            return services;
        }
    }
}
