using System;
using System.Collections.Generic;
using BookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Persistence.DBContexts;

public partial class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingSystem.Domain.Entities.Booking> Bookings { get; set; }

    public virtual DbSet<BookingItem> BookingItems { get; set; }

   // public virtual DbSet<BookingPayment> BookingPayments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    //public virtual DbSet<OutboxMessage> OutboxMessages { get; set; }

    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookingDbContext).Assembly);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
