using System;
using System.Collections.Generic;

namespace OFODBGUI.Models;

public partial class Customer
{
    public int Customersid { get; set; }

    public string? Customeremail { get; set; }

    public string Customerpassword { get; set; } = null!;

    public string? Phonenumber { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public string? Streetname { get; set; }

    public string? Buildingno { get; set; }

    public string? Floorno { get; set; }

    public string? Apartmentno { get; set; }

    public int? Totalpoints { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
