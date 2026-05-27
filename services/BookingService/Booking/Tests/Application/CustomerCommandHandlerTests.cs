using BookingSystem.Application.Common.Interfaces;
using BookingSystem.Application.Common.Interfaces.Repositories;
using BookingSystem.Application.Features.Customers.Command.UpdateCustomer;
using BookingSystem.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Application
{
    public class CustomerCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Update_Customer_Successfully()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var existingCustomer = new Customer("Old Name", "old@example.com", "0123456789");
            // reconstruct to have specific Id (domain has reconstruction ctor)
            existingCustomer = new Customer(existingCustomer.Id, existingCustomer.Name, existingCustomer.Email, existingCustomer.Phone, existingCustomer.CreatedAt);

            var repoMock = new Mock<ICustomerRepository>();
            var uowMock = new Mock<IUnitOfWork>();

            repoMock.Setup(r => r.GetByIdAsync(customerId)).ReturnsAsync((Customer?)null);
            // When GetByIdAsync called with existingCustomer.Id, return it
            repoMock.Setup(r => r.GetByIdAsync(existingCustomer.Id)).ReturnsAsync(existingCustomer);

            Customer? updatedCustomer = null;
            repoMock.Setup(r => r.Update(It.IsAny<Customer>()))
                    .Callback<Customer>(c => updatedCustomer = c);

            uowMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
                   .ReturnsAsync(1);

            var handler = new UpdateCustomerCommandHandler(uowMock.Object, repoMock.Object);

            var command = new UpdateCustomerCommand
            {
                Id = existingCustomer.Id,
                Name = "New Name",
                Email = "new@example.com",
                Phone = "0987654321"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();

            repoMock.Verify(r => r.GetByIdAsync(existingCustomer.Id), Times.Once);
            repoMock.Verify(r => r.Update(It.IsAny<Customer>()), Times.Once);
            uowMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

            updatedCustomer.Should().NotBeNull();
            updatedCustomer!.Id.Should().Be(existingCustomer.Id);
            updatedCustomer.Name.Should().Be(command.Name);
            updatedCustomer.Email.Should().Be(command.Email);
            updatedCustomer.Phone.Should().Be(command.Phone);
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_When_Customer_NotFound()
        {
            // Arrange
            var repoMock = new Mock<ICustomerRepository>();
            var uowMock = new Mock<IUnitOfWork>();

            repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                    .ReturnsAsync((Customer?)null);

            var handler = new UpdateCustomerCommandHandler(uowMock.Object, repoMock.Object);

            var command = new UpdateCustomerCommand
            {
                Id = Guid.NewGuid(),
                Name = "Any",
                Email = "any@example.com",
                Phone = "000"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNull();
            result.Error!.Detail.Should().Be("Customer not found");

            repoMock.Verify(r => r.GetByIdAsync(command.Id), Times.Once);
            repoMock.Verify(r => r.Update(It.IsAny<Customer>()), Times.Never);
            uowMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
