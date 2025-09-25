using System;
using System.Collections.Generic;

namespace Assignment_Session04_Solution.Models;

public partial class Route
{
    public int Id { get; set; }

    public string Origin { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public double Distance { get; set; }

    public string Classification { get; set; } = null!;

    public int NumOfPassengers { get; set; }

    public decimal Price { get; set; }

    public DateTime Departure { get; set; }

    public DateTime Arrival { get; set; }

    public double Duration { get; set; }

    public int AirCraftId { get; set; }

    public virtual AirCraft AirCraft { get; set; } = null!;
}
