using Booking.Domain.Entities;
using Booking.Infrastructure.Dapper;
using Booking.Infrastructure.Persistence.DBContexts;
using Booking.Infrastructure.Persistence.Repositories;
using Castle.Core.Configuration;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Infrastructure
{
    public class ServiceTests
    {
        [Fact]
        public async Task Should_Add_Service_Successfully() {
            //Arrange
            var context = CreateDbContext();
            var repo = new ServiceRepository(context);
            var service = new Service ( "Test Service", 50,  30 );

            //Act
            await repo.AddAsync(service);
            await context.SaveChangesAsync();

            //Assert
            var result = await context.Services.SingleOrDefaultAsync(x => x.Id == service.Id);

            result.Should().NotBeNull();
            result.Name.Should().Be("Test Service");
            result.Price.Should().Be(50);
        }


        private BookingDbContext CreateDbContext()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            //var options = new DbContextOptionsBuilder<BookingDbContext>()
            //    .UseInMemoryDatabase(Guid.NewGuid().ToString())
            //    .Options;
            //return new BookingDbContext(options);

            var options = new DbContextOptionsBuilder<BookingDbContext>()
            .UseSqlite(connection)
            .Options;

            var context = new BookingDbContext(options);
            context.Database.EnsureCreated(); // tạo schema
            return context;

        }
    }
}
