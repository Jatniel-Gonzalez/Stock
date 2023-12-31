using System;
using System.Collections.Generic;

namespace Stock.Models;

public partial class Product
{
    public int  IdProduct { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? AmountProduct { get; set; }

    public int IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<Movement> Movements { get; set; } = new List<Movement>();
}
