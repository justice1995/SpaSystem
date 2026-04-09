using System;
using System.Collections.Generic;

namespace BookingSystem.Infrastructure.Persistence.Models;

public partial class BookingPayment
{
    public Guid Id { get; set; }

    public Guid? BookingId { get; set; }

    public Guid? PaymentId { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
