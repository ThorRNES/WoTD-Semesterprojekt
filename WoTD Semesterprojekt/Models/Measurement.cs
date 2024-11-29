using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoTD_Semesterprojekt.Models
{
    public class Measurement
    {
        public decimal Pulse { get; set; }
        public string Date { get; set; } // Store as ISO 8601 string for simplicity
    }
}
