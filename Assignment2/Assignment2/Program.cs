
//1)
class Calculator
{
    static int Add(int num1, int num2)
    {
        return num1 + num2;
    }
    static int Sub(int num1, int num2)
    {
        return num1 - num2;
    }
    static int Mul(int num1, int num2)
    {
        return num1 * num2;
    }
    static int Div(int num1, int num2)
    {
        return num1 / num2;
    }
    static int Mod(int num1, int num2)
    {
        return num1 % num2;
    }
    static void greet(String name)
    {
        Console.WriteLine($"Hello {name}");
    }
    static void Main(String[] args)
    {
        String name = Console.ReadLine();
        greet(name);
        //int result = 0;
        //Console.WriteLine("Enter first number");
        //int num1 = Console.ReadLine();
        //Console.WriteLine("Enter second number");
        //int num2 = int.Parse(Console.ReadLine());
        //Console.WriteLine("Specify the operation\n1.Add\n2.Sub\n3.Multiply\n4.Divison\n5.Modulus\n");
        //int opr = int.Parse(Console.ReadLine());
        //int number = int.Parse(Console.ReadLine());
        //if (number % 2 == 0)
        //{
        //    Console.WriteLine($"{number} is even");
        //}
        //else
        //{
        //    Console.WriteLine($"{number} is odd");
        //}
        //switch (opr)
        //{
        //    case 1:
        //        result = Calculator.Add(num1, num2);
        //        Console.WriteLine("Result is " + result);
        //        break;
        //    case 2:
        //        result = Calculator.Sub(num1, num2);
        //        Console.WriteLine("Result is " + result);
        //        break;
        //    case 3:
        //        result = Calculator.Mul(num1, num2);
        //        Console.WriteLine("Result is " + result);
        //        break;
        //    case 4:
        //        result = Calculator.Div(num1, num2);
        //        Console.WriteLine("Result is " + result);
        //        break;
        //    case 5:
        //        result = Calculator.Mod(num1, num2);
        //        Console.WriteLine("Result is " + result);
        //        break;
        //    default:
        //        Console.WriteLine("Invalid input");
        //        break;
        //}

    }
}



//2)
//class SumOfArray
//{
//    static void Main(String[] args)
//    {
//        int sum = 0;
//        int[] arr = { 1, 2, 3, 4, 5, 6, 80 };
//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (arr[i] % 2 == 0)
//            {
//                sum += arr[i];

//            }
//        }
//        Console.WriteLine("The sum of even numbers in the array is " + sum);
//    }
//}



//3)
//class MultiplicationTable
//{
//    static void Main(String[] args)
//    {
//        Console.WriteLine("Enter the number you want the table of : ");
//        int num = int.Parse(Console.ReadLine());
//        for (int i = 1; i <= 10; i++)
//        {
//            Console.WriteLine($"{num} X {i} = {num * i}");
//        }
//    }
//}



//4)
//class Pattern
//{
//    static void Main(String[] args)
//    {
//        for (int i = 1; i <= 5; i++)
//        {
//            for (int j = 1; j <= i; j++)
//            {
//                Console.Write("* ");
//            }
//            Console.WriteLine();
//        }
//    }
//}