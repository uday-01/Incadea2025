// See https://aka.ms/new-console-template for more information

// 1.create a class and objects with different access specifiers if possible use constructors and perform calculator operations 
// 2.Implement a scienticfic calculator

using System;
using CalculatorApp; // Import the namespace

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Select Calculator Type: 1. Basic  2. Scientific");
            int calculatorType = Convert.ToInt32(Console.ReadLine());

            if (calculatorType == 1)
            {
                Console.WriteLine("Enter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Choose operation: +, -, *, /");
                char operation = Convert.ToChar(Console.ReadLine());

                Calculator calculator;
                switch (operation)
                {
                    case '+':
                        calculator = new Addition();
                        break;
                    case '-':
                        calculator = new Subtraction();
                        break;
                    case '*':
                        calculator = new Multiplication();
                        break;
                    case '/':
                        calculator = new Division();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation selected.");
                }

                double result = calculator.Calculate(num1, num2);
                Console.WriteLine($"Result: {result}");
            }
            else if (calculatorType == 2)
            {
                ScientificCalculator sciCalculator = new ScientificCalculator();
                Console.WriteLine("Choose operation: sqrt, pow, log");
                string operation = Console.ReadLine();
                double result = 0;

                if (operation == "sqrt")
                {
                    Console.WriteLine("Enter number: ");
                    double num = Convert.ToDouble(Console.ReadLine());
                    result = sciCalculator.SquareRoot(num);
                }
                else if (operation == "pow")
                {
                    Console.WriteLine("Enter base number: ");
                    double baseNum = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter exponent: ");
                    double exponent = Convert.ToDouble(Console.ReadLine());
                    result = sciCalculator.Power(baseNum, exponent);
                }
                else if (operation == "log")
                {
                    Console.WriteLine("Enter number: ");
                    double num = Convert.ToDouble(Console.ReadLine());
                    result = sciCalculator.Logarithm(num);
                }
                else
                {
                    throw new InvalidOperationException("Invalid operation selected.");
                }

                Console.WriteLine($"Result: {result}");
            }
            else
            {
                Console.WriteLine("Invalid calculator type selected.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

