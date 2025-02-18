namespace Calculator
{
    public class ScientificCalculator : Calculator
    {
        private double result;
        public ScientificCalculator() { result = 0; }
        public void FindSquare(double x)
        {
            result = x * x;
            Console.Write($"The result is {result}");
        }
        public void FindCube(double x)
        {
            result = x * x * x;
            Console.Write($"The result is {result}");
        }
        public void FindLog(double x)
        {
            result = Math.Log(x);
            Console.Write($"The result is {result}");
        }
        public void FindPower(double x,double y)
        {
            result = Math.Pow(x, y);
            Console.Write($"The result is {result}");
        }
        public void Findsqrt(double x)
        {
            result = Math.Sqrt(x);
            Console.Write($"The result is {result}");
        }
        public void Findcbrt(double x)
        {
            result = Math.Cbrt(x);
            Console.Write($"The result is {result}");
        }

    }
}
