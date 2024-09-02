using System;
using System.Collections.Generic;

namespace ROSmvc.Models;

public partial class MenuItem
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
