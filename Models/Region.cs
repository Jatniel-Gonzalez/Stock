using System;
using System.Collections.Generic;

namespace Stock.Models;

public partial class Region
{
    public int IdRegion { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }
}
