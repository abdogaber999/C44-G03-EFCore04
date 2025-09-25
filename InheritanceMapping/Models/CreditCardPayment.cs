using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Models
{
    public class CreditCardPayment : Payment
    {
        public string CardNumber { get; set; } = null!;
    }
}
