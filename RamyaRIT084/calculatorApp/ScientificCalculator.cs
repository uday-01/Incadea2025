using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class ScientificCalculator
    {
        public double SquareRoot(double num)
        {
            if (num < 0)
                throw new ArgumentException("Cannot compute square root of a negative number.");
            return Math.Sqrt(num);
        }

        public double Power(double baseNum, double exponent)
        {
            return Math.Pow(baseNum, exponent);
        }

        public double Logarithm(double num)
        {
            if (num <= 0)
                throw new ArgumentException("Logarithm input must be greater than zero.");
            return Math.Log(num);
        }
    }
}

