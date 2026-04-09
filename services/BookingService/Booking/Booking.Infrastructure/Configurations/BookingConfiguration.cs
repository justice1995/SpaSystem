using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Entities;

namespace BookingSystem.Infrastructure.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<BookingSystem.Domain.Entities.Booking>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Booking> builder)
        {
            // Table name
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.BookingCode).HasMaxLength(50);
            builder.Property(b => b.CustomerId);
            builder.Property(b => b.Status).HasMaxLength(50).HasConversion<string>();
            builder.Property(b=>b.TotalAmount).HasColumnType("decimal(18,2)");
            builder.Property(b => b.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(b => b.UpdatedAt);

            //builder.HasMany(x => x.Items);
            builder.HasMany(x => x.Items)
               .WithOne()
               .HasForeignKey("BookingId")
               .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Items)
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
