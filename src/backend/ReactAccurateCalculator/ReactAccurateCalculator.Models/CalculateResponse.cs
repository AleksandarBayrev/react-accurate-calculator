using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactAccurateCalculator.Models
{
    public class CalculateResponse
    {
        public string Equation { get; init; }
        public decimal Result { get; init; }
        public string ResultAsString { get; init; }
    }
}
