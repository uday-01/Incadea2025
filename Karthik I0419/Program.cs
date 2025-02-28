using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3.   C# Program to demonstarte byte,int,short and long

            Console.WriteLine("Size of Int: {0} \nSize of Byte: {1}", sizeof(int), sizeof(byte));
            Console.WriteLine("Size of Short: {0} \nSize of Long: {1}", sizeof(short), sizeof(long));
            Console.WriteLine("Range of Int is {0}...{1}", int.MinValue, int.MaxValue);
            Console.WriteLine("Range of Byte is {0}...{1}", byte.MinValue, byte.MaxValue);
            Console.WriteLine("Range of Short is {0}...{1}", short.MinValue, short.MaxValue);
            Console.WriteLine("Range of Long is {0}...{1}", long.MinValue, long.MaxValue);


            // 5.   Complex Statements
            int a = 70, b = 60, c = 50, d = 40;
            if ((a > b) && (b > c))
                Console.WriteLine("\n\n\nA, B, C are in decending Order");
            if (((a - b) == (c - d)) || ((b - c) != (a - d)))
                Console.WriteLine("\n\nCondition Satissfied");
            else
                Console.WriteLine("Condition not Satissfied");
        }
    }
}

// 1.   Value Types are stores in stack, when assigning copies data, Referrence TYpes are stored as heap, when assigning copies referrence.

// 2.   float - 32 bit binary variable. Value should always decalred with Suffix as 'f'
//      double - 64 bit binary variable
//      decimal - 128 bit deciaml variable


// 4.   Var is restricted to single data type and can't be changed. Dynamic is not restricted to any single data type. It can be changed to 
//      any required data type. Basically dynamic type variables are defined when return type is unknown.

