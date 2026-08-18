using System;
using System.Collections.Generic;

namespace StarSecurityServices.Models;

public partial class Client
{
    public int Id { get; set; }

    public string ClientName { get; set; } = null!;

    public string? ServicesAvailed { get; set; }

    public int? StaffAssigned { get; set; }

    public string? IconClass { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
