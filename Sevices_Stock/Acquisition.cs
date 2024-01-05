using Sevices_Stock;
using System;
using System.Collections.Generic;

namespace Stock.Models;

public partial class Acquisition
{
    public int IdProduct { get; set; }

    public int? IdSupplier { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Supplier? IdSupplierNavigation { get; set; }
}
