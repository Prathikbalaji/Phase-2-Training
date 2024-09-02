using System;
using System.Collections.Generic;

namespace ROSmvc.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustId { get; set; }

    public DateOnly DateOrdered { get; set; }

    public bool Status { get; set; }

    public virtual User Cust { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
