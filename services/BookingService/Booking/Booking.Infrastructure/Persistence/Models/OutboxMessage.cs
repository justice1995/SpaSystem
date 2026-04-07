using System;
using System.Collections.Generic;

namespace Booking.Infrastructure.Persistence.Models;

public partial class OutboxMessage
{
    public Guid Id { get; set; }

    public string? EventType { get; set; }

    public string? Payload { get; set; }

    public DateTime? OccurredOn { get; set; }

    public DateTime? ProcessedOn { get; set; }

    public string? Error { get; set; }
}
