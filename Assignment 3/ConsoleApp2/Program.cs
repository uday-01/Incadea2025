using System;
namespace Cal;
public class Program
{
    public static void Main(string[] args)
    {
        Scientific scientific = new Scientific();
        int a = 0, b = 0;

        Console.WriteLine("Enter the number 1: ");
        try
        {
            a = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid operand");
            return;
        }

        Console.WriteLine("Enter the operation to be performed");
        Console.WriteLine("Enter l for logarithm, s for sqrt, p for power, or a, b, m, d for add, sub, mul, div respectively.");
        char ch = Console.ReadLine()[0];

        if (!(ch == 'l' || ch == 's' || ch=='p'))
        {
            try
            {
                Console.WriteLine("Enter the second number: ");
                b = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid operand");
                return;
            }
        }

        switch (ch)
        {
            case '+':
                Console.WriteLine(scientific.Add(a, b));
                break;
            case '-':
                Console.WriteLine(scientific.Sub(a, b));
                break;
            case '*':
                Console.WriteLine(scientific.Mul(a, b));
                break;
            case '/':
                if (b == 0)
                    Console.WriteLine("Cannot divide by zero!");
                else
                    Console.WriteLine(scientific.Div(a, b));
                break;
            case 'l':
                Console.WriteLine(scientific.Logg(a));
                break;
            case 's':
                Console.WriteLine(scientific.Root(a));
                break;
            case 'p':
                Console.WriteLine("Enter the power exponent: ");
                try
                {
                    int exponent = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(scientific.Power(a, exponent));
                }
                catch
                {
                    Console.WriteLine("Invalid exponent");
                }
                break;
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
    }
}

