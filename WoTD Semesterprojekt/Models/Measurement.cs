using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WoTD_Semesterprojekt.Models
{
    public class Measurement
    {
        public decimal? Pulse { get; set; }
        public string Date { get; set; } // Store as ISO 8601 string for simplicity

        public Measurement()
        {
        }

        public Measurement(decimal? pulse, string date)
        {
            Pulse = pulse;
            Date = date;
        }

        public void ValidatePulse()
        {
            if (Pulse == null) throw new ArgumentNullException("Pulse cannot be null");
            if (Pulse < 0) throw new ArgumentOutOfRangeException("Pulse cannot be less than 0");
        }
        public void ValidateDate()
        {
            if (Date == null) throw new ArgumentNullException("Date cannot be null");

        }
        public override string ToString()
        {
            return $"{Pulse} {Date}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Measurement measurement &&
                   Pulse == measurement.Pulse &&
                   Date == measurement.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Pulse, Date);
        }
    }
}
