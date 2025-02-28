using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DemoApp
{
    class Conditional
    {
        static void Main(string[] args)
        {
            Selector();
        }

        static void Selector()
        {
            int Selction;
            string s;

            Console.WriteLine("Select operation to be performed: ");
            Console.WriteLine("1. Calculator\n2. Sum of Even Numbers in Array\n3. Multiplication Tables\n4. Print Pattern");
            Selction = Convert.ToInt32(Console.ReadLine());

            switch (Selction)
            {
                case 1:
                    Console.WriteLine("--- Calculator ---");
                    Calculator();
                    break;
                case 2:
                    Console.WriteLine("--- Sum of Even Numbers in Array ---");
                    SumArrayEvenNumber();
                    break;
                case 3:
                    Console.WriteLine("--- Multiplication Tables ---");
                    Multiply();
                    break;
                case 4:
                    Console.WriteLine("--- Print Pattern ---");
                    PrintPattern();
                    break;
            }
            Console.WriteLine("Do you want to continue(y/n): ");
            s = Console.ReadLine();
            if (s.ToLower() == "y")
                Selector();
        }

        static void Calculator()
        {
            int a,b,Option;
            Console.WriteLine("Select operation to be performed: ");
            Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Modulus");
            Option = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter 1st number:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd number:");
            b = Convert.ToInt32(Console.ReadLine());


            switch (Option)
            {
                case 1:
                    Console.WriteLine("\n{0}",a+b);
                    break;
                case 2:
                    Console.WriteLine("\n{0}", a - b);
                    break;
                case 3:
                    Console.WriteLine("\n{0}", a * b);
                    break;
                case 4:
                    Console.WriteLine("\n{0}",a / b);
                    break;
                case 5:
                    Console.WriteLine("\n{0}", a % b);
                    break;
            }
        }

        static void SumArrayEvenNumber()
        {
            int i,j; 
            Console.WriteLine("Define Size of Array: ");
            i = Convert.ToInt32(Console.ReadLine());
            int[] A = new int[i];
            Console.WriteLine("Enter values of Array");
            for(j=0; j<i; j++)
            {
                A[j] = Convert.ToInt32(Console.ReadLine());
            }

            i = 0;
            Console.WriteLine("\nYour Array:");
            foreach (int Num in A)
            {
                if (Num % 2 == 0)
                {
                    i += Num;
                }
                Console.WriteLine(Num);
            }

            Console.WriteLine("Sum of Even Numbers = {0}", i);

        }

        static void Multiply()
        {
            int a,b;

            Console.WriteLine("Define Integer you want to Multiply:");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Maximum multiplication factor:");
            b = Convert.ToInt32(Console.ReadLine());

            for (a = 0; a < b; a++)
            {
                Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
            }
        }

        static void PrintPattern()
        {
            int i,j,c;
            string s;

            Console.WriteLine("Enter String to Print Pattern: ");
            s = Console.ReadLine();

            Console.WriteLine("No. of line PAttern Should be Printed:");
            c = Convert.ToInt32(Console.ReadLine());

            i = 0;
            while (i < c)
            {
                j = i;
                while (j > 0)
                {
                    Console.Write(s + " ");
                    j--;
                }
                Console.WriteLine(s);
                i++;
            }
        }
    }
}
