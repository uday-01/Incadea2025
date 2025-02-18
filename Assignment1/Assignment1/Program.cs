//1
//Value types store the actual value while the reference types store the reference of strings and object.
//    In Value types , data is stored in the stack , while in reference types the data is stored in heap and the its reference is stored in stack.
//example for value types :-
//    int , float , double , long and short
//example for reference types :-
//    string , object and dynamic



//2
//The only difference between the float , double and decimal is the precision . 
//    float has the precision of 7 digits , double has the precision of 15-16 and the decimal has the precision of 27-28 digits
//when we need less precision for example, area of a circle we can use float , when we need better precision like calculating force using mass and acceleration we use double and decimal


//3
byte a = 2;
short b = 10;
int c = 456;
long d = 7890865;
Console.WriteLine("a = " + a);
Console.WriteLine("b = " + b);
Console.WriteLine("c = " + c);
Console.WriteLine("d = " + d);
Console.WriteLine("Size of byte = " + sizeof(byte));
Console.WriteLine("Size of short = " + sizeof(short));
Console.WriteLine("Size of int = " + sizeof(int));
Console.WriteLine("Size of long = " + sizeof(long));
Console.WriteLine("byte ranges between "+byte.MinValue+" and "+byte.MaxValue );
Console.WriteLine("Short ranges between "+short.MinValue+" and "+short.MaxValue );
Console.WriteLine("Int ranges between "+int.MinValue+" and "+int.MaxValue);
Console.WriteLine("Long ranges between "+long.MinValue+" and "+long.MaxValue);


//4
//var is used to initialize a value that cannot be converted to any other data type but the value can be changed with the same type of data
//while dynamic is used to initialize a value that can be converted to other type of data later in the code.

//5

int e = 10;
int f = 10;
int g = 30;
Boolean h = true;
Boolean i = false;
Console.WriteLine("e = " + e);
Console.WriteLine("f = " + f);
Console.WriteLine("g = " + g);
Console.WriteLine("e + f = "+(e+f));
Console.WriteLine("e - f = "+(e-f));
Console.WriteLine("e * f = "+(e*f));
Console.WriteLine("f / e = "+(f/e));
Console.WriteLine("f % e = "+(f%e));
Console.WriteLine(h);
Console.WriteLine(i);
Console.WriteLine(h&&i);
Console.WriteLine(h||i);

int experience = 56;
if(experience <= 12)
{
    Console.WriteLine("You are an intern");
}
else if(experience>=13 && experience <= 36)
{
    Console.WriteLine("junior developer");
}
else
{
    Console.WriteLine("Senior developer");
}




