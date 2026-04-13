using System;
using System.Collections.Generic;

namespace OFODBGUI.Models;

public partial class SpecialOffer
{
    public int Offerid { get; set; }

    public string? Offername { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public int? Minpoints { get; set; }

    public string? Dayoftheweek { get; set; }

    public virtual ICollection<MenuItem> Items { get; set; } = new List<MenuItem>();
}
