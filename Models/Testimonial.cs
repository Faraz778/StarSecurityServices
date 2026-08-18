using System;
using System.Collections.Generic;

namespace StarSecurityServices.Models;

public partial class Testimonial
{
    public int Id { get; set; }

    public string ClientName { get; set; } = null!;

    public string? Role { get; set; }

    public string Message { get; set; } = null!;

    public int Stars { get; set; }
}
