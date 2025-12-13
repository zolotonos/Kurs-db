using System;
using System.Collections.Generic;

namespace Kurs_db.Models;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public decimal Amount { get; set; }

    public string Method { get; set; } = null!;

    public DateTime? PaidAt { get; set; }

    public Guid? OrderId { get; set; }

    public virtual Order? Order { get; set; }
}
