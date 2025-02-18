// See https://aka.ms/new-console-template for more information
// C3 Advance assignment 

/* 1. Primitive Data Types & Reference Types
a) What is the difference between value types and reference types in C#? Give an example of each.
b) Write a C# program that declares an int, double, and char variable and prints their values. */

using System;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Person
{
    public string Name;


//Person p1 = new Person();
//p1.Name = "Ramya";
//Console.WriteLine(p1.Name); 

  static void Main()
    {
        int myInt = 10;
        double myDouble = 20.5;
        char myChar = 'A';

        Console.WriteLine("Integer Value: " + myInt);
        Console.WriteLine("Double Value: " + myDouble);
        Console.WriteLine("Char Value: " + myChar);
    }
}

/* 2. Casting, Boxing, and Unboxing
a) Explain implicit casting and explicit casting with an example.
b) Write a program that demonstrates boxing and unboxing using an int value. */

int num = 10;
double d = num; // Implicit casting from int to double
Console.WriteLine(d);

double d = 10.5;
int num = (int)d; // Explicit casting from double to int (fractional part lost)
Console.WriteLine(num);

// example for boxing and unboxing


class Program
{
    static void Main()
    {
        int num = 100; 
        object obj = num; // Boxing (int → object)

        Console.WriteLine("Boxed Value: " + obj);

        int unboxedNum = (int)obj; // Unboxing (object → int)
        Console.WriteLine("Unboxed Value: " + unboxedNum);
    }
}

/* 3. StringBuilder and IO Operations
a) Why should you use StringBuilder instead of string in C#?
ans: In C#, string is immutable, meaning every modification creates a new object in memory, leading to performance overhead when dealing with frequent string modifications.So, we use StringBuilder over String.
b) Write a program that uses StringBuilder to concatenate 5 strings.
c) Write a program that reads text from a file and prints its contents. */

// Using string 
string str = "";
for (int i = 0; i < 10; i++)
{
    str += i.ToString(); // Creates a new string each time
}

// Using StringBuilder 
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 10; i++)
{
    sb.Append(i); // Modifies the same instance
}

// Program Using StringBuilder to Concatenate 5 Strings

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Hello, ");
        sb.Append("this ");
        sb.Append("is ");
        sb.Append("Ramya ");
        sb.Append("R!");

        Console.WriteLine(sb.ToString()); 
    }
}

/* 4. Arrays & Methods
a) Write a method that takes an array of integers and returns the sum of all elements.
b) Write a method that finds the largest number in an array.*/

class Program
{
    static int GetArraySum(int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Sum of array elements: " + GetArraySum(arr)); // Output: 15
    }
}
// b. finds the largest number in an array

class Program
{
    static int FindLargestNumber(int[] numbers)
    {
        if (numbers.Length == 0)
            throw new ArgumentException("Array cannot be empty.");

        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
                max = num;
        }
        return max;
    }

    static void Main()
    {
        int[] arr = { 10, 5, 8, 20, 3 };
        Console.WriteLine("Largest number in array: " + FindLargestNumber(arr)); // Output: 20
    }
}


/* 5.Collections & Generic Methods
a) What is the difference between List<T> and Array in C#?
b) Write a program that stores 5 names in a List<string> and prints them.
c) Write a generic method that prints the elements of any collection (e.g., List, Array).*/

// using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve" };

        Console.WriteLine("Names in the list:");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}



class Program
{
    // Generic method to print any collection
    static void PrintCollection<T>(IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Console.WriteLine(item);
        }
    }

    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        List<string> names = new List<string> { "Alice", "Bob", "Charlie" };

        Console.WriteLine("Printing numbers array:");
        PrintCollection(numbers);

        Console.WriteLine("\nPrinting names list:");
        PrintCollection(names);
    }
}

/* 6. Streams & Serialization/Deserialization
a) What is the purpose of serialization in C#?
Serialization is the process of converting an object into a format that can be stored or transmitted and later reconstructed. In C#, serialization is used to:

Save objects to files (e.g., JSON, XML, binary format).
Send objects over networks (e.g., APIs, remote procedure calls).
Store object state for later retrieval (e.g., session data in web applications).
Copy objects in memory.

b) Write a program that serializes an object to a JSON file and then reads it back.*/
//using System;
//using System.IO;
//using System.Text.Json;

class Program
{
    // Define a class to be serialized
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    static void Main()
    {
        string filePath = "person.json";

        // Create an object
        Person person = new Person { Name = "Alice", Age = 25 };

        // Serialize object to JSON and save to a file
        string jsonString = JsonSerializer.Serialize(person);
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine("Object serialized to JSON file.");

        // Read JSON from file and deserialize it back to an object
        string readJson = File.ReadAllText(filePath);
        Person deserializedPerson = JsonSerializer.Deserialize<Person>(readJson);

        Console.WriteLine("Deserialized Object:");
        Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
    }
}

/* 7. Exception Handling
a) What is the difference between try/catch and try/finally?
try/catch: 	Used to handle exceptions gracefully.
If an exception occurs, control moves to the corresponding catch block.
try/finally: Does not handle exceptions; the finally block runs regardless of whether an exception occurs.
The finally block always executes after try, whether an exception occurs or not.
b) Write a program that handles division by zero using try/catch. */

try
{
    int result = 10/0; // Division by zero
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

// OR
class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter numerator: ");
            int nume = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter denominator: ");
            int denom = Convert.ToInt32(Console.ReadLine());

            int result = nume / denom; // May throw DivideByZeroException
            Console.WriteLine($"Result: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numbers.");
        }
        finally
        {
            Console.WriteLine("Program execution completed.");
        }
    }
}


/* 8. Async/Await
a) What is the advantage of using async and await in C#?

async and await enable asynchronous programming, which allows tasks to run without blocking the main thread.

Key Advantages:
Improved Responsiveness → Keeps UI and applications responsive by avoiding blocking calls.
Better Performance → Efficiently handles I/O-bound operations (e.g., file handling, database queries, API calls).
Simplifies Asynchronous Code → Avoids complex callbacks, making the code cleaner and more readable.
Non-Blocking Execution → The thread remains free to handle other tasks while waiting for a long-running operation to complete.
🔹 Example Use Cases:

Reading files asynchronously.
Making API requests without freezing the UI.
Running background tasks efficiently.

b) Write a simple asynchronous method that simulates a 2-second delay using Task.Delay(). */

//using System;
//using System.Threading.Tasks;

class Program
{
    static async Task SimulateDelay()
    {
        Console.WriteLine("Task started...");
        await Task.Delay(1000); // Simulates a 1sec delay
        Console.WriteLine("Task completed after 2 seconds.");
    }

    static async Task Main()
    {
        await SimulateDelay(); // Calls the async method
    }
}














