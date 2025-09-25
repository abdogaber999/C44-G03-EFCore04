using System;
using System.Collections.Generic;

namespace Assignment_Session04_Solution.Models;

public partial class Airline
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? ContactPerson { get; set; }

    public virtual ICollection<AirCraft> AirCraft { get; set; } = new List<AirCraft>();

    public virtual ICollection<AirlinePhone> AirlinePhoneAirlineId1Navigations { get; set; } = new List<AirlinePhone>();

    public virtual ICollection<AirlinePhone> AirlinePhoneAirlines { get; set; } = new List<AirlinePhone>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
