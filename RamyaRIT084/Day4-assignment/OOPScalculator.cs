// 1. Implement method overloading by creating multiple versions of the add() method that handle different data types (e.g., integers and floating-point numbers).

using System;

class Calculator
{
    // Method Overloading for Addition

    // Add two integers
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Add two floating-point numbers
    public double Add(double a, double b)
    {
        return a + b;
    }

    // Add three integers
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        // Testing method overloading with different inputs
        Console.WriteLine("Addition of two integers (5 + 10): " + calc.Add(5, 10));
        Console.WriteLine("Addition of two floating-point numbers (5.5 + 10.2): " + calc.Add(5.5, 10.2));
        Console.WriteLine("Addition of three integers (3 + 4 + 5): " + calc.Add(3, 4, 5));
    }
}

// 2. 


