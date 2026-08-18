using System;
using System.Collections.Generic;

namespace StarSecurityServices.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Address { get; set; }

    public string? ContactNumber { get; set; }

    public string? Qualification { get; set; }

    public string? Department { get; set; }

    public string? Grade { get; set; }

    public string? Achievements { get; set; }

    public DateOnly? JoiningDate { get; set; }

    public int? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
