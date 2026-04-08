using Booking.Application.Common.Interfaces;
using Booking.Application.Common.Interfaces.Queries;
using Booking.Application.Common.Interfaces.Repositories;
using Booking.Application.Features.Services.Command.CreateService;
using Booking.Application.Features.Services.Command.DeleteService;
using Booking.Application.Features.Services.Command.UpdateService;
using Booking.Application.Features.Services.DTOs;
using Booking.Application.Features.Services.Queries.GetById;
using Booking.Domain.Entities;
using FluentAssertions;
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
            repoMock.Verify(x => x.AddAsync(It.IsAny<Service>()), Times.Once);// Kiem tra xem phương thức AddAsync có được gọi đúng một lần với bất kỳ đối tượng Service nào hay không
            uowMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once); // Kiem tra xem phương thức SaveChangesAsync có được gọi đúng một lần với bất kỳ đối tượng CancellationToken nào hay không
        }

        [Fact]
        public async Task Should_Update_Service_Successfully()
        {
            // Arrange
            var repoMock = new Mock<IServiceRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            

            var existingService = new Service("Hair", 100, 30);

            repoMock.Setup(x => x.GetByIdAsync(existingService.Id))
       .ReturnsAsync(existingService);// Kiem tra xem phương thức GetByIdAsync có được gọi đúng một lần với Id của existingService hay không, và trả về existingService

            Service updatedService = null;
            repoMock.Setup(x => x.Update(It.IsAny<Service>()))
        .Callback<Service>(s => updatedService = s); // Kiem tra xem phương thức Update có được gọi đúng một lần với bất kỳ đối tượng Service nào hay không, và lưu đối tượng Service đã được cập nhật vào biến updatedService


            var handler = new UpdateServiceCommandHandler(uowMock.Object, repoMock.Object);
            var command = new UpdateServiceCommand(existingService.Id, "Haircut", 120, 45);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repoMock.Verify(x => x.Update(It.IsAny<Service>()), Times.Once);
            uowMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

            updatedService.Should().NotBeNull();
            updatedService.Id.Should().Be(existingService.Id);
            updatedService.Name.Should().Be(command.Name);
            updatedService.Price.Should().Be(command.Price);
            updatedService.Duration.Should().Be(command.Duration);
        }

        [Fact]
        public async Task Should_Return_False_When_Service_Not_Found_For_Update()
        {
            // Arrange
            var repoMock = new Mock<IServiceRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            repoMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Service)null); // Kiem tra xem phương thức GetByIdAsync có được gọi đúng một lần với bất kỳ đối tượng Guid nào hay không, và trả về null để giả lập trường hợp không tìm thấy dịch vụ
            var handler = new UpdateServiceCommandHandler(uowMock.Object, repoMock.Object);
            var command = new UpdateServiceCommand(Guid.NewGuid(), "Haircut", 120, 45);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeFalse(); // Kiem tra xem kết quả trả về có phải là false hay không, vì dịch vụ không được tìm thấy để cập nhật
        }

        [Fact]
        public async Task Should_Delete_Service_Successfully()
        {
            // Arrange
            var repoMock = new Mock<IServiceRepository>();
            var uowMock = new Mock<IUnitOfWork>();

            var existingService = new Service("Hair", 100, 30);

            // Mock: DB có sẵn service
            repoMock.Setup(x => x.GetByIdAsync(existingService.Id)).ReturnsAsync(existingService);

            // Capture object bị delete
            Service deletedService = null;
            repoMock.Setup(x => x.Delete(It.IsAny<Service>()))
        .Callback<Service>(s => deletedService = s);

            var handler = new DeleteServiceCommandHandler(uowMock.Object, repoMock.Object);
            var command = new DeleteServiceCommand {Id= existingService.Id};

            //Act
            var result = await handler.Handle(command, CancellationToken.None);
            repoMock.Verify(x => x.Delete(
                    It.Is<Service>(s => s.Id == existingService.Id)
                ), Times.Once);
            uowMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

            deletedService.Should().NotBeNull();
            deletedService.Id.Should().Be(existingService.Id);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task Should_Return_False_When_Service_Not_Found_For_Delete()
        {
            // Arrange
            var repoMock = new Mock<IServiceRepository>();
            var uowMock = new Mock<IUnitOfWork>();

            repoMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Service)null);
            var handler = new DeleteServiceCommandHandler(uowMock.Object, repoMock.Object);
            var command = new DeleteServiceCommand { Id = Guid.NewGuid() };
            
            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().BeFalse(); // Kiem tra xem kết quả trả về có phải là false hay không, vì dịch vụ không được tìm thấy để xóa
        }

        [Fact]
        public async Task Should_Same_Result_When_Find_Service_In_Delete()
        {
            //Arrange
            var repoMock = new Mock<IServiceRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            var existingService = new Service("Hair", 100, 30);
            repoMock.Setup(x=>x.GetByIdAsync(existingService.Id)).ReturnsAsync(existingService);

            var handler = new DeleteServiceCommandHandler(uowMock.Object, repoMock.Object);   
            var command = new DeleteServiceCommand { Id = existingService.Id };

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert

            repoMock.Verify(x => x.GetByIdAsync(It.Is<Guid>(x => x == existingService.Id)), Times.Once);
            
        }

        [Fact]
        public async Task Should_Return_Result_When_Find_By_Id()
        {
            //Arrange 
            var serviceQueryMock = new Mock<IServiceQuery>();
            var existingService = new ServiceDto {Id= Guid.NewGuid(), Name="Hair", Price=100, Duration=30 };

            serviceQueryMock.Setup(x => x.GetByIdAsync(existingService.Id)).ReturnsAsync(existingService);

            var handler = new GetByIdQueryHandler(serviceQueryMock.Object);
            var command = new GetByIdQuery { Id = existingService.Id };

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            serviceQueryMock.Verify(x => x.GetByIdAsync(It.Is<Guid>(x => x == existingService.Id)), Times.Once);
            result.Should().NotBeNull();
            result.Id.Should().Be(existingService.Id);
            result.Name.Should().Be(existingService.Name);

        }
    }
}
