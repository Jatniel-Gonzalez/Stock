using System;
using System.Collections.Generic;

namespace Stock.Models;

public partial class ExistenceByRegion
{
    public int? IdProduct { get; set; }

    public int? IdRegion { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Region? IdRegionNavigation { get; set; }
}
