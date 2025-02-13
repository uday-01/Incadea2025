namespace Cal
{
    public class Calculator
    {
        // Methods for addition
        public int Add(int x, int y)
        {
            return x + y;
        }

        // Methods for subtraction
        public int Sub(int x, int y)
        {
            return x - y;
        }

        // Methods for multiplication
        public int Mul(int x, int y)
        {
            return x * y;
        }

        // Methods for division
        public int Div(int x, int y)
        {
            return x / y;
        }
    }

    public class Scientific : Calculator
    {
        // Logarithm method 
        public double Logg(int x)
        {
            if (x <= 0)
            {
                Console.WriteLine("Logarithm undefined for zero or negative numbers.");
                return double.NaN;
            }
            return Math.Log(x);
        }

        // Square root method 
        public double Root(int x)
        {
            if (x < 0)
            {
                Console.WriteLine("Square root undefined for negative numbers.");
                return double.NaN;
            }
            return Math.Sqrt(x);
        }

        // Power method 
        public double Power(int x, int y)
        {
            return Math.Pow(x, y);
        }
    }
}
