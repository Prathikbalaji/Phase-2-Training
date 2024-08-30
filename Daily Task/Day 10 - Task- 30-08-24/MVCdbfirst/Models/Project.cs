using System;
using System.Collections.Generic;

namespace MVCdbfirst.Models;

public partial class Project
{
    public int Pid { get; set; }

    public string? ProName { get; set; }

    public DateTime? AllocatedDate { get; set; }

    public int Eid { get; set; }

    public virtual Employee EidNavigation { get; set; } = null!;
}
