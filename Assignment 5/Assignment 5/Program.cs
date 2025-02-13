//1.Primitive Data Types & Reference Types
//a) What is the difference between value types and reference types in C#? Give an example of each.
//b) Write a C# program that declares an int, double, and char variable and prints their values.


//a.
//Storage Stores the actual value	,Stores a reference to the value
//Default Value	0, false, etc.  	Default value is null
//Assignment Behavior	Copies the actual value	  Copies the reference (pointer)
//b.
//string str = "hello";  
//string str1;           
//int a = 10;
//char ch = 'A';
//double d = 2.324352635;
//str1 = str;
//str = str + "Hi";
//Console.WriteLine(str);
//Console.WriteLine(str1);
//Console.WriteLine(a + " " + ch +" "+ d);    


//2.Casting, Boxing, and Unboxing
//a) Explain implicit casting and explicit casting with an example.
//b) Write a program that demonstrates boxing and unboxing using an int value.

//a.
//Implicit casting happens automatically when you convert a smaller or less precise data type to a larger or more precise one. This is done without the need for explicit syntax and is safe because it does not result in data loss or overflow.
//Explicit casting, also known as type casting, is used when you need to manually convert from a larger data type to a smaller one or between types where data loss may occur. The compiler does not automatically perform these conversions, so you must explicitly tell the compiler to do so. This can be done using parentheses with the target type.

//b.
//int x = 10;
//object obj = x;  
//Console.WriteLine(obj.GetType());
//object obj1 = 10;
//int y = (int)obj1;  
//Console.WriteLine(y.GetType());


//3.StringBuilder and IO Operations
//a) Why should you use StringBuilder instead of string in C#?
//b) Write a program that uses StringBuilder to concatenate 5 strings.
//c) Write a program that reads text from a file and prints its contents.

//a.
//In C#, string is immutable, which means that once a string object is created, it cannot be changed. Every time you perform an operation on a string (like concatenation), a new string object is created. This results in memory overhead, especially when dealing with large amounts of string manipulation
//On the other hand, StringBuilder is a mutable class designed for scenarios where you need to modify strings repeatedly.It allows you to modify the content of a string without creating new string objects each time

//b.
//using System.Text;

//StringBuilder sb = new StringBuilder();
//sb.Append("Hello, ");
//sb.Append("Hi ");
//sb.Append("Everyone ");
//sb.Append("from ");
//sb.Append("Incadea");
//Console.WriteLine(sb);

//c.
//using System.IO;
//string file_path = @"C:\Users\likith.d\Desktop\hello.txt";
//try
//{
//    using (StreamReader sr = new StreamReader(file_path))
//    {
//        string line = sr.ReadToEnd();
//        Console.WriteLine(line);
//    }
//}
//catch(Exception ex)
//{
//    Console.WriteLine(ex.Message + ex.StackTrace);
//}

//4. Arrays & Methods
//a) Write a method that takes an array of integers and returns the sum of all elements.
//b) Write a method that finds the largest number in an array.

//a.
//int sums(int[] arr)
//{
//     int sum = 0;
//foreach(var i in arr)
//    {
//        sum+=i;
//    }
//return sum; 
//}
//int[] arr = { 1, 23, 23, 56, 12, 455, 75 };
//Console.WriteLine(sums(arr));

//b.
//int largest(int[] arr)
//{
//    return arr.Max();
//}
//int[] arr = { 1, 23, 23, 56, 1234, 455, 75 };
//Console.WriteLine(largest(arr));

//5.Collections & Generic Methods
//a) What is the difference between List<T> and Array in C#?
//b) Write a program that stores 5 names in a List<string> and prints them.
//c) Write a generic method that prints the elements of any collection (e.g., List, Array).

//a.
//Arrays have size fixed and whereas List has the dynamic sizes, arrys require manual resizing whereas it is dynamic in case of lists.
//b.
//List<string> names = new List<string>();
//names.Add("Ram");
//names.Add("shyam");
//names.Add("monam");
//names.Add("athmam");
//names.Add("sharam");
//foreach(var name in names)
//{
//    Console.WriteLine(name);
//}

//c.
//void prints(dynamic Generic)
//{
//    foreach(var ch in Generic)
//    {
//        Console.WriteLine(ch);
//    }
//}
//prints(names);


//6.Streams & Serialization / Deserialization
//a) What is the purpose of serialization in C#?
//b) Write a program that serializes an object to a JSON file and then reads it back.

//a.
//Serialization in C# is the process of converting an object or data structure into a format that can be easily stored or transmitted, such as a binary or text-based format.The purpose of serialization is to enable objects to be saved to disk, sent over a network, or exchanged between different applications or systems.
//b.
//using System;
//using System.IO;
//using System.Text.Json;

//public class Person
//{
//    public string Name { get; set; }
//    public int Id { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        // Create an instance of Person
//        Person person1 = new Person { Name = "Alice", Id = 1 };

//        // Serialize the object to JSON and save to a file
//        string json = JsonSerializer.Serialize(person1);
//        File.WriteAllText("person.json", json);
//        Console.WriteLine(json);

//        Console.WriteLine("Object serialized to JSON successfully!");

//        // Deserialize the JSON from the file back into a Person object
//        string jsonFromFile = File.ReadAllText("person.json");
//        Person deserializedPerson = JsonSerializer.Deserialize<Person>(jsonFromFile);

//        // Print the deserialized object
//        Console.WriteLine($"Deserialized Person: Name = {deserializedPerson.Name}, Id = {deserializedPerson.Id}");
//    }
//}


//7.Exception Handling
//a) What is the difference between try/catch and try/finally?
//b) Write a program that handles division by zero using try/catch.

//a. try catch blocks are used ti handle errors without causing intervevntion to the execution of the programm.whenever an error occurs in the try block catch block recognizes it and displays messgae regarding errors.
//.finally is a block of statement that is executed always, irrespective of error ocuurence in the code

//b.
//using System.Runtime.InteropServices.Marshalling;

//try
//{
//    int a = 9;
//    int b = 0;
//    Console.WriteLine(a/b);
//}
//catch(Exception ex)
//{
//    Console.WriteLine(ex.Message + "An unusual error occured");
//    Console.WriteLine(ex.StackTrace);
//}

//8. Async/Await
//a) What is the advantage of using async and await in C#?
//b) Write a simple asynchronous method that simulates a 2-second delay using Task.Delay().

//a.When we use async and await, we can perform tasks asynchronously without blocking the main thread.
//Efficiency: Allows the system to use resources better by not blocking threads.
//But not all the time because some situations like authentication would require a synchronous programming paradigm also.

//b.
//class programm
//{
//    static async Task Main()
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine(i);
//            await longTask();
//        }

//    }
//    static async Task longTask()
//    {
//        Console.WriteLine("1");
//        await Task.Delay(6000);
//        Console.WriteLine("2");
//    }
//}

