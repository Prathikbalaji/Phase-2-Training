using System;
using System.Collections.Generic;

namespace MVCdbfirst.Models;

public partial class Employee
{
    public int Eid { get; set; }

    public string? EmpName { get; set; }

    public decimal? EmpSalary { get; set; }

    public string? EmpDesignation { get; set; }

    public string? EmpType { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
