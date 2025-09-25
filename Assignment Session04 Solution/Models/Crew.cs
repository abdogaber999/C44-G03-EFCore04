using System;
using System.Collections.Generic;

namespace Assignment_Session04_Solution.Models;

public partial class Crew
{
    public int Id { get; set; }

    public string MajPilot { get; set; } = null!;

    public string AssisPilot { get; set; } = null!;

    public string Host1 { get; set; } = null!;

    public string Host2 { get; set; } = null!;

    public int AirCraftId { get; set; }

    public virtual AirCraft AirCraft { get; set; } = null!;
}
