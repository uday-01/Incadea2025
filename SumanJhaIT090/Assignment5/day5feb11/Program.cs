//1a) What is the difference between value types and reference types in C#? Give an example of each.

//value type
//1. It stores the direct value of the variable
//2.It uses stack to store the value.
//3.If any changes is done in value of variable later , it dont change the actual variable.
//4.If it is declared it needs not to be initialized as we need in reference type.
//Eg:-
//int x = 10;
//x = x++;
//int a = x;
//Console.WriteLine($"The value of  x is {x} and a is {a}");

//Reference type
//1.It stores the reference of the variable that stores the value.
//2.It uses Heap for its operation.
//3.If any changes are done in the re-assigned variable , it will change the actual variable value also.
//person person = new person();
//person.name = "suman";

//Console.WriteLine(person.age);
//Console.WriteLine(person.name);
//class person
//{
//    public string name;
//    public int age;
//}

//1b. Write a C# program that declares an int, double, and char variable and prints their values.

//using System;
//class Sjha
//{
//    static void Main(String[] args)
//    {
//        int a = 10;
//        double b = 80;
//        char ch = 'a';

//        Console.WriteLine($"The  value of the a is{a} and b is {b} and c is {ch}");
//    }
//}
//2.a Explain implicit casting and explicit casting with an example.

//implicit casting 
//1. implicit casting means converting from smaller datatype to a larger one.
//2. it is done internally and need not to be specified.


//explicit casting
//1.explicit casting means converting a  variable from a larger datatype to smaller datatype
//2.it needs to be done explicitly
//3.it is performed to improve the performance by managing the space

//2.b  Write a program that demonstrates boxing and unboxing using an int value.

//using System.Text;

//class boxingunboxing
//{
//    public void see()
//    {
//        int num = 10;
//        object boxed = num;

//        //unboxing 
//        int unboxednum = (int)boxed;

//        Console.WriteLine($"The  boxed number is {boxed} and the unboxed number is {unboxednum}");
//    }

//}

//3a.a) Why should you use StringBuilder instead of string in C#?

//1.StringBuilder modifies the same object, avoiding multiple memory allocations.
//2. Faster than string for frequent concatenations.
//3.strings are immutable and stringbuilder are mutable.

//3b Write a program that uses StringBuilder to concatenate 5 strings.
//using System;
//using System.Text;
//class prac

//{
//    public string concatenate()
//    {
//        StringBuilder stringBuilder = new StringBuilder();
//        stringBuilder.Append("hey");
//        stringBuilder.Append("i");
//        stringBuilder.Append("am");
//        stringBuilder.Append("suman");

//        return stringBuilder.ToString();
//    }
//    public static void Main(string[] args)
//    {
//        prac prac = new prac();
//        Console.WriteLine("The appended string is "+prac.concatenate());
//    }

//}

//class filer
//{
//    public void ReadAndPrintFile(string filePath)
//    {
//        if (File.Exists(filePath))
//        {
//            string content = File.ReadAllText(filePath);
//            Console.WriteLine("File Contents:\n" + content);
//        }
//        else
//        {
//            Console.WriteLine("File not found.");
//        }
//    }
//    public static void Main(String [] args)
//    {
//        filer reader  = new filer();
//        reader.ReadAndPrintFile("example.txt");
//    }

//}

//4a. ) Write a method that takes an array of integers and returns the sum of all elements
//public class arays
//{
//    public int sum()
//    {
//        int[] arr = { 1, 2, 3, 4, 5 };
//        int summ = 0;

//        for (int i = 0; i < arr.Length; i++)
//        {
//            summ += arr[i];
//        }
//        return summ;

//    }

//b.Write a method that finds the largest number in an array.
//    public int largest()
//    {
//        int large = 0;

//        int[] arr = { 1, 2, 3, 4, 5, 6 };

//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (arr[i] > large)
//            {
//                large = arr[i];
//            }
//        }
//        return large;

//    }


//    static void Main(String [] args)
//    {
//        arays arays = new arays();
//        Console.WriteLine("The sum of the elemets of the array is "+arays.sum());

//        arays lar = new arays();
//        Console.WriteLine("The largest number in here is "+lar.largest());
//    }
//}

//5a. What is the difference between List<T> and Array in C#?

//LIST<>
// 1.Can grow and shrink dynamically as needed.
//2.lightly slower due to resizing and additional features.
//3.Has useful methods like Add(), Remove(), Contains(), etc.

//Array
//1.Has a fixed size once created; cannot grow or shrink.
//2.Faster because it has a fixed memory allocation.
//3. Only supports basic indexing and length properties.

//5b. b) Write a program that stores 5 names in a List<string> and prints them.

//class Program
//{
//    public void ShowData()
//    {
//        List<string> strings = new List<string> { "Suman", "Kumar", "Jha", "Bangalore", "India" };
//        Console.Write("The names are: ");
//        foreach (var v in strings)
//        {
//            Console.Write(v + " "); 
//        }
//        Console.WriteLine(); 
//    }

//    static void Main(string[] args)
//    {
//        Program pg = new Program();
//        pg.ShowData(); 
//    }
//}

//5c.Write a generic method that prints the elements of any collection (e.g., List, Array).



//class generics
//{

//    public  static void dtypes(dynamic  arr)
//    {
//        foreach (var type in arr)
//        {
//            Console.WriteLine(type+" ");
//        }

//    }
//    static void Main(String [] args)
//    {
//        List<string> list = new List<string>();

//        list.Add("Suman");
//        list.Add("Jha");

//        int[] arr = { 1, 2, 3, 4, 5, 6, };
//        dtypes(arr);
//        dtypes(list);
//    }

//}


//6a a) What is the purpose of serialization in C#?

//serialization is used to convert the raw data into streams of data ,for example we have an api which send the user details based on the id , the 
//serializtion converts the data into stream of the data and helps to communicate among different apis.

//6b Write a program that serializes an object to a JSON file and then reads it back.


//using System.Text.Json;
//using System;

//class person
//{
//    public string name { get; set; }
//    public int age { get; set; }
//    public string city { get; set; }
//}

//class program
//{
//    static void Main(string[] args)
//    {
//        string fp = "person.json";
//        person person = new person { name ="suaman",age = 22,city = "Bangalore"};

//        File.WriteAllText(fp, JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true }));
//        person deserializedPerson = JsonSerializer.Deserialize<person>(File.ReadAllText(fp));

//        Console.WriteLine($"Name: {deserializedPerson.name}, Age: {deserializedPerson.age}, City: {deserializedPerson.city}");

//    }
//}

//7 a) What is the difference between try/catch and try/finally?

//try
//try block contains the code that has a potential change of getting and error
//try  block checks for the error in the code.

//catch

//catch block executes whenever there is an error in the try block 
//catch block ensures the smooth flow of tge program.

//finally
//finally block executes either there is an error in try block or not ,
//it executes irrespective of the try catch  block 

//7b. Write a program that handles division by zero using try/catch.

//class trycatch
//{
//    public void checks()
//    {
//        int num = 20;
//        int divisor = 0;

//        try
//        {
//            int res = num / divisor;
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine("The error has occured due to division by zerio");
//        }
//        finally
//        {
//            Console.WriteLine("This is finally  block that runs anyhow");
//        }
//    }

//    static void Main(string[] args)
//    {
//        trycatch tc = new trycatch();
//        tc.checks();
//    }
//}

//8a a) What is the advantage of using async and await in C#?

//Async and Await is used for a optimized programming practices 
//Async say that the programs or functions will execute in an asynchronus manner and no program will wair for any progan to comlete.
//we can also make the programs to wait for a few tiume usinf Await feature .
//asyunc await helps the programmmer to satisfy the required conditons of the logic and handle multiple situtiions wisely

//8b.
//class progam
//{
//    static async Task delaything()
//    {
//        Console.WriteLine("The task has been started and will end soon...");
//        await Task.Delay(2000);
//        Console.WriteLine("The task is delayed by 2 seconds");
//    }
//    static async Task Main()
//    {
//        await delaything();
//    }
//}