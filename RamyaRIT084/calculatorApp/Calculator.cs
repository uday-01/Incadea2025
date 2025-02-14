using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Calculator
    {
        public virtual double Calculate(double num1, double num2)
        {
            return 0;
        }
    }

    public class Addition : Calculator
    {
        public override double Calculate(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    public class Subtraction : Calculator
    {
        public override double Calculate(double num1, double num2)
        {
            return num1 - num2;
        }
    }

    public class Multiplication : Calculator
    {
        public override double Calculate(double num1, double num2)
        {
            return num1 * num2;
        }
    }

    public class Division : Calculator
    {
        public override double Calculate(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return num1 / num2;
        }
    }
}

