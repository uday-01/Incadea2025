// See https://aka.ms/new-console-template for more information

// 1. In any given array find Sum of Even Numbers

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of elements in the array: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[size];

        // Taking input dynamically
        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Element {i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Call method to calculate sum of even numbers
        int evenSum = GetSumOfEvenNumbers(numbers);

        // Display the result
        Console.WriteLine($"Sum of even numbers: {evenSum}");
    }

    static int GetSumOfEvenNumbers(int[] arr)
    {
        int sum = 0;
        foreach (int num in arr)
        {
            if (num % 2 == 0) // Check if number is even
            {
                sum += num;
            }
        }
        return sum;
    }
}

// 2. Multiplication Table Using a For Loop

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number to print its multiplication table: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\nMultiplication Table of {number}:");

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{number} x {i} = {number * i}");
        }
    }
}


// 3. Make use of while loop and print the below 
/* 
 * 
 * *
 * * *
 * * * *
*/

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of rows for the pattern: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nSimple Pattern:");
        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine(); // Move to next line
        }
    }
}
