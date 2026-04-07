using Booking.Domain.Entities;
using Booking.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Mappings
{
    public static class ServiceMapping
    {
        public static Domain.Entities.Service ToDomain(this Models.Service entity)
        {
            return new Domain.Entities.Service(
                 entity.Id,
                entity.Name!,
                entity.Price ?? 0,
                entity.Duration ?? 0,
                entity.CreatedAt ?? DateTime.UtcNow
            );
        }

        public static Persistence.Models.Service ToPersistence(this Domain.Entities.Service domain)
        {
            return new Persistence.Models.Service
            {
                Id = domain.Id,
                Name = domain.Name,
                Price = domain.Price,
                Duration = domain.Duration,
                CreatedAt = domain.CreatedAt

            };
        }
    }
}
