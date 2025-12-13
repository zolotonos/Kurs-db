using System;
using System.Collections.Generic;

namespace Kurs_db.Models;

public partial class Supplier
{
    public Guid SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactEmail { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
