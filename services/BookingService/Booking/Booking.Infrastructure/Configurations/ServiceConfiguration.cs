using BookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            // Table name
            builder.ToTable("Services");

            // Primary key
            builder.HasKey(x => x.Id);

            // Id
            builder.Property(x => x.Id)
                   .ValueGeneratedNever(); // vì bạn tự set Guid

            // Name
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            // Price
            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // Duration
            builder.Property(x => x.Duration)
                   .HasDefaultValueSql("GETUTCDATE()");

            // CreatedAt
            builder.Property(x => x.CreatedAt)
                   .IsRequired();

            // Index (optional nhưng nên có)
            builder.HasIndex(x => x.Name);
        }
    }
}
