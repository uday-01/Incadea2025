namespace Calculator
{
    public class Calculator
    {
        private double result;
        public Calculator() { result = 0; }
        public void Add(double a, double b) { result = a + b;Console.WriteLine($"The answer is {result}"); }
        public void Subtract(double a, double b) { result = a - b; Console.WriteLine($"The answer is {result}"); }
        public void Multiply(double a, double b) { result = a * b; Console.WriteLine($"The answer is {result}"); }
        public void Divide(double a, double b) {  result = a / b; Console.WriteLine($"The answer is {result}"); }
        public void Modulus(double a , double b) { result = a % b; Console.WriteLine($"The answer is {result}"); }

        public void getResult()
        {
            Console.WriteLine(result);
        }

    }
}