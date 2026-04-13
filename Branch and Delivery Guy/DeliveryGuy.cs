using System;
using System.Collections.Generic;

namespace OFODBGUI.Models;

public partial class DeliveryGuy
{
    public int Deliveryguysid { get; set; }

    public string? Deliveryguyssn { get; set; }

    public string? Deliveryguyname { get; set; }

    public int? Numberofordersdelivered { get; set; }

    public DateOnly? Dateofjoining { get; set; }

    public decimal? Rating { get; set; }

    public string? Vehicletype { get; set; }

    public DateOnly? Contractexpirationdate { get; set; }

    public int? Branchid { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
