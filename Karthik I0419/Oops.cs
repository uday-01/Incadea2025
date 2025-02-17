using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoApp
{
    // 1. Method OverLoading
    public class Oops
    {
        static void Main(string[] args)
        {
            //OverLoadingCalculator();
            GetResult();
        }

        public double Add(params double[] Value)
        {
            if (Value.Length == 1)
            {
                return Value[0];
            }
            else if (Value.Length > 1)
            {
                double sum = 0;
                foreach (var num in Value)
                {
                    sum += num;
                }
                return sum;
            }
            else
            {
                return 0;
            }
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(params double[] Value)
        {
            double result = 1;
            foreach (var num in Value)
            {
                result *= num;
            }
            return result;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Error: Division by zero is not allowed.");
            }
            return x / y;
        }
        static void OverLoadingCalculator()
        {
                Oops calc = new Oops();
                Console.WriteLine(calc.Add(2, 3));
                Console.WriteLine(calc.Subtract(10, 4));
                Console.WriteLine(calc.Multiply(2, 3));
                Console.WriteLine(calc.Divide(10, 2));
                try
                {
                    Console.WriteLine(calc.Divide(10, 0));
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        //3. MathUtils
        public static double Power(double baseValue, int exponent)
        {
            return Math.Pow(baseValue, exponent);
        }

        public static void GetResult()
        {
            Console.WriteLine("Input Base Number:");
            double BaseNum = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input Exponential Number:");
            int ExpoNum = Convert.ToInt32(Console.ReadLine());
            double result = Power(BaseNum, ExpoNum);
            Console.WriteLine("Result: {0}", result);
        }
    }

    // 2. Method Overriding
    class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes sound");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("bhouww!");
        }
    }

    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }

    class Override
    {
        static void Main(string[] args)
        {
            //Dog Dog = new Dog();
            //Dog.MakeSound();  
            //Animal Animal = new Dog();
            //Animal.MakeSound();

            //5. Ploymorphism
            Animal[] animals = new Animal[]{new Dog(),new Cat(),new Dog(),new Cat()};
            foreach (var animal in animals)
            {
                animal.MakeSound();
            }
        }
    }

    //4. Employee

    public class Employee
    {
        static int employeeCount = 0;

        public string Name { get; set; }
        public int EmployeeId { get; set; }

        public Employee(int employeeId ,string name)
        {
            Name = name; EmployeeId = employeeId;
            employeeCount++;  
        }

        public static int GetEmployeeCount()
        {
            return employeeCount;
        }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine("Employee ID: {0}", EmployeeId);
            Console.WriteLine("Employee Name: {0}", Name);
        }
    }

    class EmployeeRes
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee( 1, "Karuturi");
            Employee emp2 = new Employee(2, "Siva");
            Employee emp3 = new Employee(3, "Karthik");

            emp1.DisplayEmployeeInfo(); emp2.DisplayEmployeeInfo(); emp3.DisplayEmployeeInfo();
            Console.WriteLine("Total Employees: {0}", Employee.GetEmployeeCount());
        }
    }

}
