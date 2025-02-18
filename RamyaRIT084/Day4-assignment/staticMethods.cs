// 3. Create a class MathUtils that contains a static method power() to calculate the power of a number. The method should accept two parameters: the base and the exponent. Ensure that this method can be accessed without creating an instance of the class.

using System;

class MathUtils
{
    // Static method to calculate power
    public static double Power(double baseNum, int exponent)
    {
        return Math.Pow(baseNum, exponent);
    }
}

class Program
{
    static void Main()
    {
        // Calling the static method without creating an instance
        Console.WriteLine("Enter base number: ");
        double baseNum = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter exponent: ");
        int exponent = Convert.ToInt32(Console.ReadLine());

        // Directly calling the static method
        double result = MathUtils.Power(baseNum, exponent);

        Console.WriteLine($"{baseNum} raised to the power {exponent} is: {result}");
    }
}
