using System;
using System.Collections.Generic;

namespace Booking.Infrastructure.Persistence.Models;

public partial class Booking
{
    public Guid Id { get; set; }

    public string? BookingCode { get; set; }

    public Guid? CustomerId { get; set; }

    public string? Status { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BookingItem> BookingItems { get; set; } = new List<BookingItem>();
}
