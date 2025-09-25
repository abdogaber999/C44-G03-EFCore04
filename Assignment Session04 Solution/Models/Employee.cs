using System;
using System.Collections.Generic;

namespace Assignment_Session04_Solution.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string Gender { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int BdYear { get; set; }

    public int BdMonth { get; set; }

    public int BdDay { get; set; }

    public string? Qualifications { get; set; }

    public int AirlineId { get; set; }

    public virtual Airline Airline { get; set; } = null!;
}
