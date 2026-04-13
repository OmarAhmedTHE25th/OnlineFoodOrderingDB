using System;
using System.Collections.Generic;

namespace OFODBGUI.Models;

public partial class Branch
{
    public int Branchid { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public string? Phonenumber { get; set; }

    public TimeOnly? Openingtime { get; set; }

    public TimeOnly? Closingtime { get; set; }

    public virtual ICollection<DeliveryGuy> DeliveryGuys { get; set; } = new List<DeliveryGuy>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
