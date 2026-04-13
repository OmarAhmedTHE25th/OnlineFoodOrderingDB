using System;
using System.Collections.Generic;

namespace OFODBGUI.Models;

public partial class MenuItem
{
    public int Itemid { get; set; }

    public string? Itemname { get; set; }

    public string? Itemdescription { get; set; }

    public string? Category { get; set; }

    public bool? Availability { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<SpecialOffer> Offers { get; set; } = new List<SpecialOffer>();
}
