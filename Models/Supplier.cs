﻿using System;
using System.Collections.Generic;

namespace Stock.Models;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Contact { get; set; }
}
