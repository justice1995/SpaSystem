using System;
using System.Collections.Generic;

namespace Booking.Infrastructure.Persistence.Models;

public partial class BookingItem
{
    public Guid Id { get; set; }

    public Guid? BookingId { get; set; }

    public string? ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Booking? Booking { get; set; }
}
