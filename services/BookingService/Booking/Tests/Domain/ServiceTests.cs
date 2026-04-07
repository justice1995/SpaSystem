using Booking.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Domain
{
    public class ServiceTests
    {
        [Fact]
        public void Should_Create_Service_With_Valid_Data()
        {
            var service = new Service("Hair", 100, 30);

            service.Id.Should().NotBeEmpty();
            service.Name.Should().Be("Hair1");
        }

        [Fact]
        public void Should_Update_Service_Correctly()
        {
            var service = new Service("Hair", 100, 30);

            service.Update("VIP", 200, 60);

            service.Name.Should().Be("VIP");
        }

        [Fact]
        public void Should_Not_Allow_Negative_Price()
        {
            Action act = () => new Service("Test", -1, 30);

            act.Should().Throw<ArgumentException>();
        }
    }
}
