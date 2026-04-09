using BookingSystem.Domain.Entities;
using BookingSystem.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Persistence.Mappings
{
    public static class CustomerMapping
    {
        public static Domain.Entities.Customer ToDomain(this Models.Customer entity)
        {
            return new Domain.Entities.Customer(
                entity.Id,
                entity.Name!,
                entity.Email!,
                entity.Phone!,
                entity.CreatedAt ?? DateTime.UtcNow
            );
        }

        public static Persistence.Models.Customer ToPersistence(this Domain.Entities.Customer domain)
        {
            return new Persistence.Models.Customer
            {
                Id = domain.Id,
                Name = domain.Name,
                Email = domain.Email,
                Phone = domain.Phone,
                CreatedAt = domain.CreatedAt
            };
        }
    }
}