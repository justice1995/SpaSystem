using System;
using System.Collections.Generic;

namespace Booking.Infrastructure.Persistence.Models;

public partial class Customer
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }
}
