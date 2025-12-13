using System;
using System.Collections.Generic;

namespace Kurs_db.Models;

public partial class Address
{
    public Guid AddressId { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? PostalCode { get; set; }

    public string Country { get; set; } = null!;

    public Guid? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
