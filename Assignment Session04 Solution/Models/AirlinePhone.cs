using System;
using System.Collections.Generic;

namespace Assignment_Session04_Solution.Models;

public partial class AirlinePhone
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int AirlineId { get; set; }

    public int? AirlineId1 { get; set; }

    public virtual Airline Airline { get; set; } = null!;

    public virtual Airline? AirlineId1Navigation { get; set; }
}
