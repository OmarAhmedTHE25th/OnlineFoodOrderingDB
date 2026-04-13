using System;
using System.Collections.Generic;

namespace OFODBGUI.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public DateTime? Datetime { get; set; }

    public string? Status { get; set; }

    public string? Paymentmethod { get; set; }

    public int? Customersid { get; set; }

    public int? Branchid { get; set; }

    public int? Deliveryguysid { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customers { get; set; }

    public virtual DeliveryGuy? Deliveryguys { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
