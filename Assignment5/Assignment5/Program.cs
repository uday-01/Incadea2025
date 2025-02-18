//1.Primitive Data Types & Reference Types
//a) What is the difference between value types and reference types in C#? Give an example of each.

//value types : Value types holds the actual data and are stored in the stack
//example
//int a = 10;
//int b = a;
//b = 20;
//Console.WriteLine($"a = {a} and b = {b}");

//reference types : Reference types holds the reference or the memory address where the actual data is stored.
//example
//Student s1 = new Student();
//s1.Id = 101;
//Student s2 = s1;
//s2.Id = 201;
//Console.WriteLine($"s1.Id = {s1.Id} and s2.Id = {s2.Id}");
//class Student
//{
//    public int Id { get; set; }
//}



//b) Write a C# program that declares an int, double, and char variable and prints their values.

//int a = 10;
//double b = 3.14;
//char c = '@';
//Console.WriteLine($"a = {a} : {a.GetType()} \nb = {b} : {b.GetType()} \nc = {c} : {c.GetType()}");




//2.Casting, Boxing, and Unboxing

//a) Explain implicit casting and explicit casting with an example.

//implicit casting happens automatically when you convert a smaller data type to a larger data type. Here there is no loss of data.
//example 
//int a = 10;
//double b = a;
//Console.WriteLine($"a = {a} : {a.GetType()}\nb = {b} : {b.GetType()}");

//explicit casting requires us to manually convert larger data type to smaller one . Here we may face loss of data
//example
//double a = 3.142;
//int b = (int)a;
//Console.WriteLine($"a = {a} : {a.GetType()}\nb = {b} : {b.GetType()}");

//b) Write a program that demonstrates boxing and unboxing using an int value.

//boxing
//int num = 10;
//object boxed = num;
//Console.WriteLine($"{boxed} : {boxed.GetType()}");

////unboxing
//int unboxed = (int)boxed;
//Console.WriteLine($"{unboxed} : {unboxed.GetType()}");



//3.StringBuilder and IO Operations
//a) Why should you use StringBuilder instead of string in C#?

//In c# , string is immutable which means you cannot change its value , if you try to change its value a new object is created which can be memory consuming,
//    whereas stringBuilder is mutable which means you can its value without creating new object improving the performance


//b) Write a program that uses StringBuilder to concatenate 5 strings.

//using System.Text;

//StringBuilder sb = new StringBuilder("I");
//Console.WriteLine($"String : {sb}");
//sb.Append(" am workig");
//Console.WriteLine($"String : {sb}");
//sb.Append(" as an");
//Console.WriteLine($"String : {sb}");
//sb.Append(" intern");
//Console.WriteLine($"String : {sb}");
//sb.Append(" at Incadea.");
//Console.WriteLine($"String : {sb}");


//c) Write a program that reads text from a file and prints its contents.

//String path = "C:\\Users\\yashas.achar\\Desktop\\test.txt";
//String texts = File.ReadAllText(path);
//Console.WriteLine(texts);


//4.Arrays & Methods

//a) Write a method that takes an array of integers and returns the sum of all elements.

//class Program
//{
//    public static int SumOfElements(int[] nums)
//    {
//        int sum = 0;
//        foreach (int i in nums)
//        {
//            sum += i;
//        }
//        return sum;
//    }
//    public static void Main(string[] args)
//    {
//        int[] arr = { 10, 20, 40 };
//        int res = SumOfElements(arr);
//        Console.WriteLine($"The sum of all the elements of the array is {res}");
//    }
//}

//b) Write a method that finds the largest number in an array.

//class Program
//{
//    public static int LargestElement(int[] nums)
//    {
//        int largest = int.MinValue;
//        for (int i = 0; i < nums.Length; i++)
//        {
//            if (nums[i] > largest)
//                largest = nums[i];
//        }

//        return largest;
//    }
//    public static void Main(string[] args)
//    {
//        int[] arr = { 10, 80, 20, 40 };
//        int res = LargestElement(arr);
//        Console.WriteLine($"The largest element in the array is {res}");
//    }
//}


//5.Collections & Generic Methods
//a) What is the difference between List<T> and Array in C#?

//*Array is of fixed size which means that its size cannot be changed whereas the size of the list can be changed
//*Arrays is used to store homogeneous type of elements whereas list can store heterogeneous types
//*Arrays uses index for contiguous memory allocation whereas in List the data is stored in non-contiguous memory location. 


//b) Write a program that stores 5 names in a List<string> and prints them.

//List<String> pandavas = new List<string>();
//pandavas.Add("Bhima");
//pandavas.Add("Yudhishtira");
//pandavas.Add("Arjuna");
//pandavas.Add("Nakula");
//pandavas.Add("Sahadeva");

//foreach (var pandava in pandavas)
//{
//    Console.WriteLine(pandava);
//}


//c) Write a generic method that prints the elements of any collection (e.g., List, Array).


//class Program
//{
//    public static void PrintData(dynamic data)
//    {
//        foreach (var item in data)
//        {
//            Console.WriteLine(item);
//        }
//    }

//    public static void Main(String[] args)
//    {
//        int[] arr = { 23, 14, 6, 90 };
//        List<String> pandavas = new List<string>();
//        pandavas.Add("Bhima");
//        pandavas.Add("Yudhishtira");
//        pandavas.Add("Arjuna");
//        pandavas.Add("Nakula");
//        pandavas.Add("Sahadeva");
//        Console.WriteLine("Printing integer array : ");
//        PrintData(arr);
//        Console.WriteLine("Printing string list : ");
//        PrintData(pandavas);
//    }
//}


//6.Streams & Serialization / Deserialization
//a) What is the purpose of serialization in C#?

//serialization is the process of converting an object into a json or xml format
//*It is useful when storing data in database.
//*By serializing , it is easy to transfer data over network


//b) Write a program that serializes an object to a JSON file and then reads it back.

//using System.Text.Json;


//class Employee
//{
//    public int Id { get; set; }
//    public String Name { get; set; }
//}
//class Program
//{
//    public static void Main(String[] args)
//    {
//        Employee employee = new Employee()
//        {
//            Id = 101,
//            Name = "Yashas"
//        };
//        Console.WriteLine("Before serializing : " + employee.GetType());
//        string serializedData = JsonSerializer.Serialize(employee);
//        Console.WriteLine($"After serializing : {serializedData} , Type: {serializedData.GetType()}");

//        var deserializedData = JsonSerializer.Deserialize<Employee>(serializedData);
//        Console.WriteLine("After deserializing : " + deserializedData.GetType());
//    }
//}


//7.Exception Handling
//a) What is the difference between try/catch and try/finally?

//All the risky code where there is possibility of runtime errors , those code we write it in the try block,
//and to handle those exceptions we write the handling code in catch block . Whenever the exception occurs the catch block is executed.
//and if exceptions dont occur the catch block is skipped .
//whereas the finally block will always be executed regardless of the exception occurance.



//b) Write a program that handles division by zero using try/catch.

//int a = 10;
//int b = 0;

//try
//{
//    int c = a / b;
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
//finally
//{
//    Console.WriteLine("Program completed");
//}

//8.Async / Await
//a) What is the advantage of using async and await in C#?

//Synchronous nature of programming executs the code line by line.If there is a line that is responsible to getData from API,
//such lines take time to fetch the data . due to this , other lines will be waiting for the completion of this line impacting
//the performance of the program . 
//Therefore async and await programming runs the program asynchronously improving the performance of program.

//b) Write a simple asynchronous method that simulates a 2-second delay using Task.Delay().

class Program
{
    public static async Task getData()
    {
        Console.WriteLine("Getting Data");
        await Task.Delay(2000);
        Console.WriteLine("Got Data");
    }
    static async Task Main(String[] args)
    {
        Console.WriteLine("Program Started");
        await getData();
        Console.WriteLine("Program ended");
    }
}
