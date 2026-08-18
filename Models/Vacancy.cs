using System;
using System.Collections.Generic;

namespace StarSecurityServices.Models;

public partial class Vacancy
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Department { get; set; }

    public string? City { get; set; }

    public string? JobType { get; set; }

    public string? Description { get; set; }

    public DateOnly PostedDate { get; set; }

    public bool IsFilled { get; set; }
}
