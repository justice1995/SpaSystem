using System;
using System.Collections.Generic;
using Booking.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Persistence.DBContexts;

public partial class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Models.Booking> Bookings { get; set; }

    public virtual DbSet<BookingItem> BookingItems { get; set; }

    public virtual DbSet<BookingPayment> BookingPayments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<OutboxMessage> OutboxMessages { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Booking>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Bookings_CustomerId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BookingCode).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<BookingItem>(entity =>
        {
            entity.HasIndex(e => e.BookingId, "IX_BookingItems_BookingId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ServiceName).HasMaxLength(100);

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingItems)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK_BookingItems_Bookings");
        });

        modelBuilder.Entity<BookingPayment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OutboxMessage>(entity =>
        {
            entity.HasIndex(e => e.ProcessedOn, "IX_Outbox_Processed");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EventType)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OccurredOn).HasColumnType("datetime");
            entity.Property(e => e.ProcessedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
