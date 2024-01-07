using System;
using System.Collections.Generic;

namespace Sevices_Stock;

public partial class Movement
{
    public int IdMotion { get; set; }

    public int? IdProduct { get; set; }

    public string? TypeMotion { get; set; }

    public DateTime? DateAndTime { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
