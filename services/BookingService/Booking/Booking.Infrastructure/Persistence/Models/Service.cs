using System;
using System.Collections.Generic;

namespace Booking.Infrastructure.Persistence.Models;

public partial class Service
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Duration { get; set; }

    public DateTime? CreatedAt { get; set; }
}
