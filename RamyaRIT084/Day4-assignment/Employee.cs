/* 4. In a new class called Employee, implement both a static method for tracking the number of employees and an instance method for displaying an employee’s information. The static method should keep a count of how many Employee objects have been created. The instance method should display the employee’s name and ID.
Example:
Static method: public static int getEmployeeCount()
Instance method: public void displayEmployeeInfo() */

using System;

class Employee
{
    private static int employeeCount = 0; // Static variable to track employee count
    private string name;
    private int id;

    // Constructor to initialize employee details and increment count
    public Employee(string name, int id)
    {
        this.name = name;
        this.id = id;
        employeeCount++; // Increment employee count for every new employee
    }

    // Static method to get employee count
    public static int GetEmployeeCount()
    {
        return employeeCount;
    }

    // Instance method to display employee information
    public void DisplayEmployeeInfo()
    {
        Console.WriteLine($"Employee ID: {id}, Name: {name}");
    }
}

class Program
{
    static void Main()
    {
        // Creating Employee objects
        Employee emp1 = new Employee("Alice", 101);
        Employee emp2 = new Employee("Bob", 102);
        Employee emp3 = new Employee("Charlie", 103);

        // Displaying employee information using instance method
        emp1.DisplayEmployeeInfo();
        emp2.DisplayEmployeeInfo();
        emp3.DisplayEmployeeInfo();

        // Calling static method to get total employee count
        Console.WriteLine($"Total Employees: {Employee.GetEmployeeCount()}");
    }
}
