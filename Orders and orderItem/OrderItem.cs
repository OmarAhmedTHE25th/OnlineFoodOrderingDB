using System;
using System.Collections.Generic;

namespace OFODBGUI.Models;

public partial class OrderItem
{
    public int Orderid { get; set; }

    public int Itemid { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual MenuItem Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
