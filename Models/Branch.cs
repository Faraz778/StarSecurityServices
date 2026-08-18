using System;
using System.Collections.Generic;

namespace StarSecurityServices.Models;

public partial class Branch
{
    public int Id { get; set; }

    public string Region { get; set; } = null!;

    public string Cities { get; set; } = null!;

    public string? Phone { get; set; }

    public string? ContactPerson { get; set; }

    public string? Address { get; set; }
}
