using System;
class Sjha
{
    static void Main(String[] args)
    {

        //Q1.  Method OverLoading that is using different calculation operations

        Calculator calc = new Calculator();

        var res = calc.Add(1, 2);

        Console.WriteLine("The sum of two elements are" + res);
        Console.WriteLine("The sum of two elements are" + calc.Add(1, 2, 3));
        Console.WriteLine("The sum of two elements are" + calc.Add(1.900, 2.678));

        Console.WriteLine("The subtraction of two elements are" + calc.subtract(5, 3));
        Console.WriteLine("The subtraction of the three numbers is" + calc.subtract(2, 3, 54));

        Console.WriteLine("The product of multiplication of different data type is " +calc.multiply(5, 3.5));

        Console.WriteLine("The product of division of different data type is " + calc.division(5, 15));

        //2.Method Overriding


        Animal anm = new Animal();
        anm.Makesound();
        
        Animal abb = new Dog();
        abb.Makesound();

        //Q3. calling the power() method directly from the class without
        //creating an instance of the class.

        Console.WriteLine("the resultant power operation is" +MathUtils.power(2,5));


        //Q4.

        Employee emp1 = new Employee("suman", 101);
        Employee emp2 = new Employee("jha", 102);
        Employee emp3 = new Employee("kumar", 103);

        emp1.displayEmployeeInfo();
        emp2.displayEmployeeInfo();
        emp3.displayEmployeeInfo();

        Console.WriteLine($"Total Employees: {Employee.getEmployeeCount()}");


        //Q5

        Animals anml = new Animals();
        anml.doSound();

        cat cm = new cat();
        cm.doSound();

        dog dog = new dog();
        dog.doSound();



    }






}