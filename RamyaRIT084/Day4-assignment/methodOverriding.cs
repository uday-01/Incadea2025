/* 2. Method Overriding
Task: Create a superclass called Animal and a subclass called Dog. The Animal class should have a method makeSound() that prints a generic sound, and the Dog class should override makeSound() to print a dog-specific sound like "Woof!". Demonstrate method overriding by calling makeSound() from an instance of the Dog class.
Example:
In Animal: public void makeSound() { System.out.println("Some generic animal sound"); }
In Dog: @Override public void makeSound() { System.out.println("Woof!"); }
Requirements:
Implement the Animal and Dog classes.
Demonstrate method overriding by calling the overridden method on a Dog object.*/

using System;

// Base class: Animal
class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Some generic animal sound");
    }

    public virtual void PerformAction()
    {
        Console.WriteLine("The animal does something...");
    }
}

// Derived class: Dog
class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }

    public override void PerformAction()
    {
        Console.WriteLine("The dog wags its tail happily!");
    }

    public void Fetch()
    {
        Console.WriteLine("The dog fetches the ball.");
    }
}

// Derived class: Cat
class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow! Meow!");
    }

    public override void PerformAction()
    {
        Console.WriteLine("The cat purrs and rubs against your leg.");
    }

    public void Climb()
    {
        Console.WriteLine("The cat climbs the tree.");
    }
}

// Derived class: Cow
class Cow : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Moo! Moo!");
    }

    public override void PerformAction()
    {
        Console.WriteLine("The cow grazes peacefully in the field.");
    }
}

// Derived class: Bird
class Bird : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Chirp! Chirp!");
    }

    public override void PerformAction()
    {
        Console.WriteLine("The bird flaps its wings and soars high.");
    }
}

class Program
{
    static void Main()
    {
        // Manually creating objects
        Dog myDog = new Dog();
        Cat myCat = new Cat();
        Cow myCow = new Cow();

        Console.WriteLine("\n--- Dog Actions ---");
        myDog.MakeSound();
        myDog.Fetch();

        Console.WriteLine("\n--- Cat Actions ---");
        myCat.MakeSound();
        myCat.Climb();

        Console.WriteLine("\n--- Cow Actions ---");
        myCow.MakeSound();
        myCow.PerformAction(); // Calling overridden method
    }
}
