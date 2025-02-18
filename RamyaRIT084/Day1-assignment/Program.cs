// See https://aka.ms/new-console-template for more information

/* 1. Define and differentiate between Value Types and Reference Types in C#. Provide examples.
 * 
 * 1. Value Types:
Value types store data directly in memory. When a value type is assigned to another variable or passed to a method, a copy of the value is made. This means that changes to one variable do not affect the other.

Memory Allocation: Stored in the stack.
Assignment Behavior: When assigned to another variable, a copy of the value is created.
Passing to Methods: When passed to methods, a copy is passed (by value).
Default Values: Value types have a default value (e.g., 0 for numeric types, false for booleans, etc.). 

 2. Reference Types:
Reference types store a reference (memory address) to the data in memory, rather than the actual data itself. When a reference type is assigned to another variable or passed to a method, the reference (not the actual object) is copied, meaning both variables refer to the same object in memory.

Memory Allocation: Stored in the heap (though the reference itself is stored on the stack).
Assignment Behavior: When assigned to another variable, both variables point to the same object.
Passing to Methods: When passed to methods, the reference is passed (by reference), meaning the method can modify the original object.
Default Values: Reference types have a default value of null (e.g. objects, string, Arrays, interface, etc.). */

// value type demo

int a = 20;
bool b = false;
float c = 1.7387f;
double d = 3646.47364734;

Console.WriteLine("a " + a);
Console.WriteLine("b " + b);
Console.WriteLine("c " + c);
Console.WriteLine("d " + d);

// reference type demo

string e = "hello";

//  -----------------------------------------------------------------------------------------------------------------------------------

/*
 * 2. What are the differences between float, double, and decimal? Give a scenario where each should be used.
 * 
 * In C#, float, double, and decimal are all used to represent floating-point numbers (numbers with decimal points), but they differ in precision, range, and use cases.
   1. float:
   usecase: Used for scientific calculations, graphics, and low-precision, performance-sensitive applications
   size: 4 bytes
   
   2. double:
   usecase:  Ideal for general-purpose calculations where more precision than float is needed but high precision (like in financial applications).
   size: 8 bytes

   3. decimal:
   usecase: Used for financial and monetary calculations requiring high precision
   size: 16 bytes */

float temp = 98.7f;
double dist = 57.87;
decimal prise = 374.99m;

/* 
 * 3. Write a C# program to demonstrate the use of byte, short, int, and long. Print their size and range using sizeof().
 */
 
        // Demonstrate byte
        byte byteVar = 255;  // Range: 0 to 255
        Console.WriteLine("byte:");
        Console.WriteLine("Size: " + sizeof(byte) + " byte");
        Console.WriteLine("Range: " + byte.MinValue + " to " + byte.MaxValue);
        Console.WriteLine();

        // Demonstrate short
        short shortVar = -32768;  // Range: -32,768 to 32,767
        Console.WriteLine("short:");
        Console.WriteLine("Size: " + sizeof(short) + " bytes");
        Console.WriteLine("Range: " + short.MinValue + " to " + short.MaxValue);
        Console.WriteLine();

        // Demonstrate int
        int intVar = 2147483647;  // Range: -2,147,483,648 to 2,147,483,647
        Console.WriteLine("int:");
        Console.WriteLine("Size: " + sizeof(int) + " bytes");
        Console.WriteLine("Range: " + int.MinValue + " to " + int.MaxValue);
        Console.WriteLine();

        // Demonstrate long
        long longVar = 9223372036854775807L;  // Range: -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
        Console.WriteLine("long:");
        Console.WriteLine("Size: " + sizeof(long) + " bytes");
        Console.WriteLine("Range: " + long.MinValue + " to " + long.MaxValue);

/* 4. Explain the difference between var and dynamic in C#.
 * 
 In C#, both var and dynamic are used for variable declarations.
var:

Compile-Time Type Inference: When you use var, the type of the variable is inferred by the compiler at compile time.
Static Typing: Even though the type is inferred, it still behaves as a statically typed variable.
Must be Initialized: A variable declared with var must be initialized at the time of declaration because the type needs to be inferred immediately.
Type Safety: Since the type is determined at compile-time, var provides type safety.

dynamic:

Runtime Type Resolution: The type of a dynamic variable is determined at runtime.
No Compile-Time Type Checking: Since the type is resolved at runtime, the compiler doesn't check for type errors until the code actually runs. This can lead to runtime errors if the operations are invalid for the actual type of the object.
Flexible but Risky: dynamic provides flexibility, allowing you to assign values of any type, but it sacrifices the safety and performance benefits of compile-time type checking.

5. Write some complex statements where it uses arithmetic , logical, comparision and assignment operators. */

// Example 1: Arithmetic, Comparison, and Assignment Operators

int x = 10;
int y = 20;
int z = 5;

bool result1 = (x + y) > (z * 2);
Console.WriteLine("Result1: " + result1);

x += y * 2;
bool result2 = (x % 2 == 0) && (x > 30);
Console.WriteLine("Result2: " + result2);

int finalResult = (x - y) * z;
Console.WriteLine("Final Result: " + finalResult);

// Example 2: Logical, Comparison, Arithmetic, and Assignment Operators with Multiple Conditions

int f = 30;
int g = 10;
int h = 15;

bool condition1 = (f - g) > c && (g * 2) == (c + 5);
Console.WriteLine("Condition1: " + condition1);

if ((f > g || h == 15) && !(g == 20))
{
    f -= 5;
    g += 10;
}

Console.WriteLine("Updated f: " + f);
Console.WriteLine("Updated g: " + g);

int result = (f * g) / (g - 10);
Console.WriteLine("Result: " + result);







