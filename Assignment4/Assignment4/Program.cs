
//1) Method Overloading
//Task: Create a class called Calculator that has multiple methods to perform addition, subtraction, multiplication, and division. Implement method overloading by creating multiple versions of the add() method that handle different data types (e.g., integers and floating-point numbers). Ensure that the class can handle both single and multiple parameters.
//Example:
//add(int a, int b)
//add(double a, double b)
//add(int a, int b, int c)
//Requirements:
//Define the methods for addition with different parameter types.
//Ensure the methods behave as expected when passing different combinations of integers and floats.


//class Calculator
//{
//    public static void Add(int a, int b)
//    {
//        Console.WriteLine($"The sum is {a + b}");
//    }
//    public static void Add(double a, double b)
//    {
//        Console.WriteLine($"The sum is {a + b}");
//    }
//    public static void Add(int a, int b, int c)
//    {
//        Console.WriteLine($"The sum is {a + b + c}");
//    }
//    public static void Subtract(int a, int b)
//    {
//        Console.WriteLine($"The difference is {a - b}");
//    }
//    public static void Multiply(int a, int b)
//    {
//        Console.WriteLine($"The multiplication is {a * b}");
//    }
//    public static void Divide(int a, int b)
//    {
//        try
//        {
//            Console.WriteLine($"The division is {a / b}");
//        }
//        catch (ArithmeticException ex)
//        {
//            Console.WriteLine(ex.ToString());
//        }
//    }
//}
//class Program
//{
//    public static void Main(String[] args)
//    {
//        Calculator.Add(2, 4);
//        Calculator.Add(3.45, 5.78);
//        Calculator.Add(3, 4, 5);
//        Calculator.Subtract(10, 5);
//        Calculator.Multiply(20, 2);
//        Calculator.Divide(19, 2);
//        Calculator.Divide(12, 0);
//    }
//}


//2)Task: Create a superclass called Animal and a subclass called Dog. The Animal class should have a method makeSound() that prints a generic sound, and the Dog class should override makeSound() to print a dog-specific sound like "Woof!". Demonstrate method overriding by calling makeSound() from an instance of the Dog class.
//Example:
//In Animal: public void makeSound() { System.out.println("Some generic animal sound"); }
//In Dog: @Override public void makeSound() { System.out.println("Woof!"); }
//Requirements:
//Implement the Animal and Dog classes.
//Demonstrate method overriding by calling the overridden method on a Dog object.


//class Animal
//{
//    public virtual void MakeSound()
//    {
//        Console.WriteLine("Some generic animal sound");
//    }
//}
//class Dog : Animal
//{
//    public override void MakeSound()
//    {
//        Console.WriteLine("Woof!");
//    }
//}
//class Program
//{
//    public static void Main(String[] args)
//    {
//        Animal obj = new Dog();
//        obj.MakeSound();
//    }
//}

//3)
//Task: Create a class MathUtils that contains a static method power() to calculate the power of a number. The method should accept two parameters: the base and the exponent. Ensure that this method can be accessed without creating an instance of the class.
//Example:
//public static double power(double base, int exponent) { return Math.pow(base, exponent); }
//Requirements:
//Implement the static power() method.
//Demonstrate calling the power() method directly from the class (i.e., MathUtils.power()), without creating an instance.


//class MathUtils
//{
//    public static double Power(double num, int exponent)
//    {
//        return Math.Pow(num, exponent);
//    }
//}
//class Program
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("Enter the base number");
//        double num = double.Parse(Console.ReadLine());
//        Console.WriteLine("Enter the exponent");
//        int exponent = int.Parse(Console.ReadLine());
//        var result = MathUtils.Power(num, exponent);
//        Console.WriteLine($"The result is {result}");
//    }
//}

//4)Combining Static and Instance Methods
//Task: In a new class called Employee, implement both a static method for tracking the number of employees and an instance method for displaying an employee’s information.The static method should keep a count of how many Employee objects have been created. The instance method should display the employee’s name and ID.
//Example:
//Static method: public static int getEmployeeCount()
//Instance method: public void displayEmployeeInfo()
//Requirements:
//The Employee class should maintain a static counter for how many instances of the class have been created.
//The displayEmployeeInfo() method should print the employee's name and ID.
//Create multiple Employee objects and demonstrate both static and instance method functionality.


//class Employee
//{
//    public static int EmployeeCount = 0;
//    public String Name { get; set; }
//    public int EmployeeID { get; set; }
//    public Employee(int Id, string name)
//    {
//        EmployeeCount += 1;
//        this.Name = name;
//        this.EmployeeID = Id;
//    }
//    public static int GetEmployeeCount()
//    {
//        return EmployeeCount;
//    }
//    public void displayEmployeeInfo()
//    {
//        Console.WriteLine($"Employee ID : {this.EmployeeID} , Name : {this.Name}");
//    }

//}
//class Program
//{
//    public static void Main(string[] args)
//    {
//        Employee e1 = new Employee(101, "Yashas");
//        Employee e2 = new Employee(102, "Likith");
//        Employee e3 = new Employee(102, "Suman");
//        Employee e4 = new Employee(104, "John");
//        int count = Employee.GetEmployeeCount();
//        e1.displayEmployeeInfo();
//        e2.displayEmployeeInfo();
//        e3.displayEmployeeInfo();
//        e4.displayEmployeeInfo();
//        Console.WriteLine($"The number of employees created is {count}");
//    }
//}


//5)
//Task: Expand the Animal class with another subclass, Cat. Implement a polymorphic method makeSound() that differs between Dog and Cat. Create an array of Animal objects (including Dog and Cat), and iterate through it, calling the makeSound() method for each animal.
//Requirements:
//Create the Cat subclass and override makeSound().
//Demonstrate polymorphism by calling makeSound() on an array of Animal objects, and see how it behaves differently for Dog and Cat instances.

//using System.Collections;

//class Animal
//{
//    public virtual void MakeSound()
//    {
//        Console.WriteLine("Some generic animal sound");
//    }
//}
//class Dog : Animal
//{
//    public override void MakeSound()
//    {
//        Console.WriteLine("Woof!");
//    }
//}
//class Cat : Animal
//{
//    public override void MakeSound()
//    {
//        Console.WriteLine("Meow!");
//    }
//}
//class Program
//{
//    public static void Main(String[] args)
//    {
//        List<Animal> animalList = new List<Animal>();
//        animalList.Add(new Dog());
//        animalList.Add(new Cat());
//        foreach (Animal animal in animalList)
//        {
//            animal.MakeSound();
//        }
//    }
//}
