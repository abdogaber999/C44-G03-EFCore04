using System;
using System.Collections.Generic;

namespace Assignment_Session04_Solution.Models;

public partial class AirCraft
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public int Capacity { get; set; }

    public int AirlineId { get; set; }

    public virtual Airline Airline { get; set; } = null!;

    public virtual ICollection<Crew> Crews { get; set; } = new List<Crew>();

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
