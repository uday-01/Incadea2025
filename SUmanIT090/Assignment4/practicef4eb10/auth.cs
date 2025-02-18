//using System.Reflection.Metadata;

//1.Method Overloading
//Task: Create a class called Calculator that has multiple methods to perform addition, subtraction, multiplication, and division. Implement method overloading by creating multiple versions of the add() method that handle different data types (e.g., integers and floating-point numbers). Ensure that the class can handle both single and multiple parameters.
//Example:
//add(int a, int b)
//add(double a, double b)
//add(int a, int b, int c)
//Requirements:
//Define the methods for addition with different parameter types.
//Ensure the methods behave as expected when passing different combinations of integers and floats.

using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;


public class Calculator()
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
    public int Add(double a, double b)
    {
        return (int)(a + b);
    }

    public int subtract (int a, int b)
    {
        return a - b;
    }

    public int subtract (int a, int b, int c)
    {
        return a - b + c;
    }
    public double multiply (int a, double b) 
    {
        return a * b; 
    }

    public double division ( int a, int b)
    {
        return b / a;
    }
        
}


//2.Method Overriding
//Task: Create a superclass called Animal and a subclass called Dog. The Animal class should have a method makeSound() that prints a generic sound
//, and the Dog class should override makeSound() to print a dog-specific sound like "Woof!".
//Demonstrate method overriding by calling makeSound() from an instance of the Dog class.
//Example:
//In Animal: public void makeSound() { System.out.println("Some generic animal sound"); }
//In Dog: @Override public void makeSound() { System.out.println("Woof!"); }
//Requirements:
//Implement the Animal and Dog classes.
//Demonstrate method overriding by calling the overridden method on a Dog object.



public   class Animal
{
    public  virtual void Makesound()
    {
        Console.WriteLine("The animla makes a generic sound in nature");
    }
    
}
public class Dog :Animal
{
    public override void Makesound()
    {
        Console.WriteLine("The dog barks");
    }
}



//3.Static Methods
//Task: Create a class MathUtils that contains a static method power() to calculate the power of a number.
//The method should accept two parameters: the base and the exponent. Ensure that this method can be accessed without
//creating an instance of the class.
//Example:
//public static double power(double base, int exponent) { return Math.pow(base, exponent); }
//Requirements:
//Implement the static power() method.
//Demonstrate calling the power() method directly from the class (i.e., MathUtils.power()), without creating an instance.


public  class MathUtils
{
    public static double power( int basee , int exponent)
    {
        return Math.Pow(basee, exponent);
    }
}


//4.Combining Static and Instance Methods
//Task: In a new class called Employee, implement both a static method for tracking the number of employees
//and an instance method for displaying an employee’s information.The static method should keep a count of
//how many Employee objects have been created. The instance method should display the employee’s name and ID.
//Example:
//Static method: public static int getEmployeeCount()
//Instance method: public void displayEmployeeInfo()
//Requirements:
//The Employee class should maintain a static counter for how many instances of the class have been created.
//The displayEmployeeInfo() method should print the employee's name and ID.
//Create multiple Employee objects and demonstrate both static and instance method functionality.

//class Employee
//{
//    private static int employeeCount = 0;
//    private string name;
//    private int id;

//    public Employee(string name, int id)
//    {
//        this.name = name;
//        this.id = id;
//        employeeCount++;
//        }

//    public static int GetEmployeeCount()
//    {
//        return employeeCount;
//    }

//    public void DisplayEmployeeInfo()
//    {
//        Console.WriteLine($"Employee ID: {this.id}, Name: {this.name}");
//    }

    

//}

class Employee
{
    private static int employeecount = 0;
    private string name;
    private int id;

    public Employee(string name, int id)
    {
        this.name = name;
        this.id = id;
        employeecount++;
    }

    public static int getEmployeeCount()
    {
        return employeecount;
    }

    public void displayEmployeeInfo()
    {
        Console.WriteLine($"the employee is {id} and the name associated to this id is {name}");
    }

}


//5. Polymorphism (Optional, Extension)
//Task: Expand the Animal class with another subclass, Cat. Implement a polymorphic method
//makeSound() that differs between Dog and Cat. Create an array of Animal objects (including Dog and Cat),
//and iterate through it, calling the makeSound() method for each animal.
//Requirements:
//Create the Cat subclass and override makeSound().
//Demonstrate polymorphism by calling makeSound() on an array of Animal objects,
//and see how it behaves differently for Dog and Cat instances.


class Animals
{
    public virtual void doSound()
    {
        Console.WriteLine("This is the main sound");
    }
}

class cat : Animals
{
    public override void doSound()
    {
        Console.WriteLine("The cat does MEOW");
    }
}
class dog : Animals
{
    public override void doSound()
    {
        Console.WriteLine("The dog does BARK");
    }
}
