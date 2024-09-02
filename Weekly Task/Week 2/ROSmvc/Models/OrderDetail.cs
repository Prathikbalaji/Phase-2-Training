using System;
using System.Collections.Generic;

namespace ROSmvc.Models;

public partial class OrderDetail
{
    public int Odid { get; set; }

    public int Oid { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public virtual MenuItem Item { get; set; } = null!;

    public virtual Order OidNavigation { get; set; } = null!;
}
