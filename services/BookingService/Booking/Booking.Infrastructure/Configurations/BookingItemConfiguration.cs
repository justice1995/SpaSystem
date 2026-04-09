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
    public class BookingItemConfiguration : IEntityTypeConfiguration<BookingItem>
    {
        public void Configure(EntityTypeBuilder<BookingItem> builder)
        {

            builder.ToTable("BookingItems");
            builder.HasKey(b => b.Id);
            builder.Property(b=>b.Id).ValueGeneratedNever();
            
            builder.Property(b => b.ServiceId).IsRequired();
            builder.Property(b => b.ServiceName).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(b => b.Quantity).IsRequired();
            builder.Property(b => b.CreatedAt).IsRequired().HasColumnType("datetime2");

            // FK (shadow property)
            builder.Property<Guid>("BookingId");
            builder.HasIndex("BookingId");
            builder.Ignore(b => b.TotalPrice);

        }
    }
}
