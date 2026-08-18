using System;
using System.Collections.Generic;

namespace StarSecurityServices.Models;

public partial class Service
{
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? Description { get; set; }

    public string? IconClass { get; set; }
}
