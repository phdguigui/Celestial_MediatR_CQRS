using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celestial.API.Domain.ValueObjects
{
    public class Position
    {
        public double RightAscension { get; set; }

        public double Declination { get; set; }

        public double? Distance { get; set; }
    }
}
