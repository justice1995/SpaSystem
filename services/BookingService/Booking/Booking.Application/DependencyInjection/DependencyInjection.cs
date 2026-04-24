using BookingSystem.Application.Factories;
using BookingSystem.Application.Features.Services.Command.CreateService;
using BookingSystem.Application.Interfaces;
using BookingSystem.Application.Services;
using BookingSystem.Application.Strategies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //MediatR
    //        services.AddMediatR(cfg =>
    //cfg.RegisterServicesFromAssembly(typeof(CreateServiceCommand).Assembly));
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));


            services.AddScoped<ISalaryStrategy, FullTimeSalaryStrategy>();
            services.AddScoped<ISalaryStrategy, CommissionSalaryStrategy>();
            services.AddScoped<ISalaryStrategy, HourlySalaryStrategy>();

            // Factory
            services.AddScoped<ISalaryStrategyFactory, SalaryStrategyFactory>();

            // Service
            services.AddScoped<SalaryService>();

            return services;
        }
    }
}
