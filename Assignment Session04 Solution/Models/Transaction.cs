using System;
using System.Collections.Generic;

namespace Assignment_Session04_Solution.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public int AirlineId { get; set; }

    public virtual Airline Airline { get; set; } = null!;
}
