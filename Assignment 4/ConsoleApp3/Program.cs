//1.calculator cal = new calculator();
//Console.WriteLine(  cal.add(2, 3));
//Console.WriteLine(cal.add(7, 6, 9));
//Console.WriteLine(cal.add(9.8, 64.875899));
//class calculator
//{
//    public int x,y;
//    public int add(int x, int y)
//    {
//        return x + y;
//    }
//   public  double add(double x, double y)
//    {

//        return x + y;
//    }
//    public int add(int x, int y, int z)
//    {
//        return x + y + z;
//    }
//}

//2.
//class Animal
//{
//    public virtual void makesound()
//    {
//        Console.WriteLine("Generic sound");

//    }

//}
//class Dog : Animal
//{
//    public override void makesound()
//    {
//        Console.WriteLine("Wooof");

//    }
//}
//class Cat : Animal
//{
//    public override void makesound()
//    {
//        Console.WriteLine("Meow");

//    }
//}



//3.

//Console.WriteLine(MathUtlis.power(8, 9));
//class MathUtlis()
//{
//    public static double power(double bae, int exponent)
//    {
//return Math.Pow(bae, exponent);
//    }
//}


//4.
//public class Employee
//{
//    private static int employeeCount = 0;
//    private string employeeName;
//    private int employeeId;
//    public Employee(string employeeName, int employeeId)
//    {
//        this.employeeName = employeeName;
//        this.employeeId = employeeId;
//        employeeCount++;
//    }
//    public void displayInfo()
//    {
//        Console.WriteLine("Employee Name : "+ employeeName +" | "+ " Employee ID" + employeeId);  
//    }

//    public static void getEmployeecount()
//    {
//        Console.WriteLine("Total Employees"+ employeeCount);
//    }
//    public static void Main()
//    {
//        Employee e1 = new Employee("John",234567);
//        Employee e2 = new Employee("Ram", 9757);
//        Employee e3 = new Employee("Akbar", 56623);
//        Employee e4 = new Employee("sardar", 123456);

//        e1.displayInfo();
//        e2.displayInfo();
//        e3.displayInfo();
//        e4.displayInfo();
//        Employee.getEmployeecount();
//    }
//}


//5.
//List <Animal> ani = new List<Animal> ();
//ani.Add(new Dog());
//ani.Add(new Cat ());
//ani.Add(new Dog());
//ani.Add(new Cat ());
//foreach(var ch in ani)
//{
//    ch.makesound();
//}

//class Animal
//{
//    public virtual void makesound()
//    {
//        Console.WriteLine("Generic sound");

//    }

//}
//class Dog : Animal
//{
//    public override void makesound()
//    {
//        Console.WriteLine("Wooof");

//    }
//}
//class Cat : Animal
//{
//    public override void makesound()
//    {
//        Console.WriteLine("Meow");

//    }
//}


