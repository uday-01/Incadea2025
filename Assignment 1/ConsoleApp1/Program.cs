//1. value types store tha actual data and the value is tored in stack whereas reference types stores references and in heap whereas address is stored in stack.

//2. float: 32-bit, used for less precision 
//double: 64 - bit, used for most floating-point calculations requiring higher precision   
//decimal: 128 - bit, used for high-precision calculations

float f = 3.14159f;  
Console.WriteLine(f);

double d = 3.14159265358979;  
Console.WriteLine(d);

decimal m = 3.14159265358979m;  
Console.WriteLine(m);

//3.
//Byte
        byte b = 255;
Console.WriteLine($"Byte: Size = {sizeof(byte)} bytes, Range = {byte.MinValue} to {byte.MaxValue}");

// Short
short s = 32000;
Console.WriteLine($"Short: Size = {sizeof(short)} bytes, Range = {short.MinValue} to {short.MaxValue}");

// Int
int i = 2147483647;
Console.WriteLine($"Int: Size = {sizeof(int)} bytes, Range = {int.MinValue} to {int.MaxValue}");

// Long
long l = 9223372036854775807;
Console.WriteLine($"Long: Size = {sizeof(long)} bytes, Range = {long.MinValue} to {long.MaxValue}");

//4.
//var: The type is determined at compile - time and cannot be changed once assigned; provides compile-time checking.
//dynamic: The type is determined at runtime, allowing it to change during execution; bypasses compile-time checking.

//5.
Console.WriteLine(((5>3)&&(6<9)) || (4>9));