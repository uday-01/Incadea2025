using System;

class Sjha
{
    static void Main(String[] args)
    {
        int num1 = 10;
        int num2 = 20;

        Console.WriteLine(Calculate(num1, num2, "add"));  // we are calling the calculate function here and passing the parameters in that.
        Console.WriteLine(Calculate(num1, num2, "sub"));
        Console.WriteLine(Calculate(num1, num2, "mul"));
        Console.WriteLine(Calculate(num1, num2, "div"));
        Console.WriteLine(Calculate(num1, num2, "mod"));


        Console.WriteLine("NEXT QUESTION");



        //2)In any given array find Sum of Even Numbers

        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                sum = sum + arr[i];
            }

        }
        Console.WriteLine($"the sum of even number is{sum}");



        Console.WriteLine("NEXT QUESTION");




        //3)Multiplication Table Using a For Loop

        Console.WriteLine("Enter the number you want to find the table of");
        int num = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"The iterations are{num * i} ");
        }


        Console.WriteLine("NEXT QUESTION");




        //4)Make use of while loop and print the below 
        //*
        //**
        //***
        //****
        //*****

        int j = 1;
        while (j <= 5)
        {
            for (int i = 0; i < j; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            j++;
        }





    }


    static string Calculate(int num1, int num2, string s)
    {
        if (s == "add")
        {
            return $"The sum of {num1} and {num2} is {num1 + num2}";
        }
        else if (s == "sub")
        {
            return $"The subtraction of {num1} and {num2} is {num1 - num2}";
        }
        else if (s == "mul")
        {
            return $"The multiplication of {num1} and {num2} is {num1 * num2}";
        }
        else if (s == "div")
        {
            return $"The division of {num1} and {num2} is {num2 / num1}";
        }
        else if (s == "mod")
        {
            return $"The division of {num1} and {num2} is {num1 % num2}";
        }

        else
        {
            return "INVALID";
        }
    }
}