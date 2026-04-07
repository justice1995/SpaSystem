using Booking.Application.Common.Interfaces;
using Booking.Application.Common.Interfaces.Repositories;
using Booking.Application.Features.Services.Command.CreateService;
using Booking.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Application
{
    public class ServiceTests
    {
        [Fact]
        public async Task Should_Create_Service_Successfully()
        {
            // Arrange
            var repoMock = new Mock<IServiceRepository>();
            var uowMock = new Mock<IUnitOfWork>();

            var handler = new CreateServiceCommandHandler(repoMock.Object, uowMock.Object);

            var command = new CreateServiceCommand ("Hair",100,30 );

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repoMock.Verify(x => x.AddAsync(It.IsAny<Service>()), Times.Once);
            uowMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
