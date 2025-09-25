using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public int Speed { get; set; }
    }
}
