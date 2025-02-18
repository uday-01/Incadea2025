namespace Calculator;
class Program
{
    static void Main(String[] args)
    {
        ScientificCalculator obj = new ScientificCalculator();
        double num1;
        double num2;
        Console.WriteLine("Enter the operation to be performed\n (+,-,*,/,%)");
        Console.WriteLine("1.Find square \n2.Find cube \n3.Find log \n4.Power \n5.square root \n6.cube root  ");
        char opr = Console.ReadLine()[0];
        switch (opr)
        {
            case '+': 
                Console.WriteLine("Enter the first number");
                 num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Second number");
                 num2 = double.Parse(Console.ReadLine());
                obj.Add(num1, num2);
                break;
            case '-':
                Console.WriteLine("Enter the first number");
                 num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Second number");
                 num2 = double.Parse(Console.ReadLine());
                obj.Subtract(num1, num2);
                break;
            case '*':
                Console.WriteLine("Enter the first number");
                num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Second number");
                num2 = double.Parse(Console.ReadLine());
                obj.Multiply(num1, num2);
                break;
            case '/':
                Console.WriteLine("Enter the first number");
                num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Second number");
                num2 = double.Parse(Console.ReadLine());
                obj.Divide(num1, num2);
                break;
            case '%':
                Console.WriteLine("Enter the first number");
                num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Second number");
                num2 = double.Parse(Console.ReadLine());
                obj.Modulus(num1, num2);
                break;
            case '1':
                Console.WriteLine("Enter the number");
                num1 = double.Parse(Console.ReadLine());
                obj.FindSquare(num1);
                break;
            case '2':
                Console.WriteLine("Enter the number");
                num1 = double.Parse(Console.ReadLine());
                obj.FindCube(num1);
                break;
            case '3':
                Console.WriteLine("Enter the number");
                num1 = double.Parse(Console.ReadLine());
                obj.FindLog(num1);
                break;
            case '4':
                Console.WriteLine("Enter first number");
                num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter first number");
                num2 = double.Parse(Console.ReadLine());
                obj.FindPower(num1,num2);
                break;
            case '5':
                Console.WriteLine("Enter the number");
                num1 = double.Parse(Console.ReadLine());
                obj.Findsqrt(num1);
                break;
            case '6':
                Console.WriteLine("Enter the number");
                num1 = double.Parse(Console.ReadLine());
                obj.Findcbrt(num1);
                break;
            default: Console.WriteLine("Invalid operator");
                break;
        }

        
    }
}