using System;
using System.Collections.Generic;

namespace StarSecurityServices.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
