using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Models
{
    public class CashPayment : Payment
    {
        public string Currency { get; set; } = null!;
    }
}
