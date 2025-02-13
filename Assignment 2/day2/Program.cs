class hello
{
    static void Main(string[] args)
    {
        calculator();
        sumofeven();
        Multiplication();
        pattern();
    }

    static void calculator()
{
        int a, b;
    Console.WriteLine("Enter the number 1:");
        try {
             a = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid operand");
        }
    
    Console.WriteLine("Enter Number 2:");
        try
        {
            b = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid operand");
        }
        Console.WriteLine("Enter the operation to be performed");
    char ch = Console.ReadLine()[0];
    switch (ch)
    {
        case '+': Console.WriteLine("Addition"+ (a + b)); break;
        case '-': Console.WriteLine("Subtarction"+ (a - b)); break;
        case '*': Console.WriteLine("Multiplication"+ (a * b)); break;
        case '/': Console.WriteLine("Division"+(a / b)); break;
        default: Console.WriteLine("Invalid operation"+ ch);break;
    }
}


static void sumofeven()
{
    int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
    int sum=0;
    Console.WriteLine("the given array is :");
    foreach(var i in arr)
    {
        Console.Write(i + " ");
    }
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] % 2 == 0)
        {
            sum += arr[i];
        }
    }
    Console.WriteLine(" ");
    Console.WriteLine(sum);
}
    static void Multiplication()
    {
        Console.WriteLine("Enter the number to get the multiplication table");
        int num = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(num + " " + "*" + " " + i + " " + num * i);
        }

    }
    static void pattern()
    {
        int row = 1;
        int column = 1;
        while (row < 5)
        {
            column = 1;
            while (column < row)
            {
                Console.Write("*");
                column++;
            }
            Console.WriteLine();
            row++;
        }
    }

}
