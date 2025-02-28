using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    class C_Adv
    {
        private static object console;

        static async Task Main(string[] args)
        {
            //DataTypes();
            //BoxUnBox();
            //stringBuilderOperations();
            //FileOutput();
            //SumArrayNumber();
            //ListOperate();
            //SerializeDeserialize();
            await DelayAsync();
        }

        //1.   Value Types are stores in stack, when assigning copies data, Referrence TYpes are stored as heap, when assigning copies referrence.
        static void DataTypes()
        {
            int a = 1; double b = 1.23; char c = 'A';

            Console.WriteLine("Integer: " + a); Console.WriteLine("Double: " + b); Console.WriteLine("Char: " + c);
        }

        //2. Implicit casting is done by compiler and it converts lower to higher data types. Explicit casting is to be defined by user and used to
        //      convert higher data types to lower.
        static void BoxUnBox()
        {
            int d = 100;
            object boxed = d;

            Console.WriteLine("Boxed: " + d);

            int unboxed = (int)boxed;

            Console.WriteLine("Unboxed: " + unboxed);
        }

        //3. Stringbuilder is used to decrease memory consumption. when compared with string stringBuilder increases leght of string dynamically.
        static void stringBuilderOperations()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Hello"); sb.Append(" "); sb.Append("Employees");
            sb.Append(" "); sb.Append("from"); sb.Append(" ");
            sb.Append("Karthik");

            Console.WriteLine(sb.ToString());
        }

        static void FileOutput()
        {
            string filePath = "C:/Users/karuturi.sivakarthik/OneDrive - Volaris Group/Documents/Sample.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);

                    Console.WriteLine("File content:\n");
                    Console.WriteLine(fileContent);
                }
                else
                {
                    Console.WriteLine("File not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        //4. Arrays & Methods
        static void SumArrayNumber()
        {
            int i;

            int[] A = new int[] { 1, 3, 5, 7, 8, 9 };

            i = 0;
            Console.WriteLine("Your Array:");
            foreach (int Num in A)
            {
                    i += Num; Console.WriteLine(Num);
            }

            Console.WriteLine("Sum of Numbers in Array = {0}", i);
            Console.WriteLine("Largest Number in Array = {0}", FindLargestNumber(A));

        }
        static int FindLargestNumber(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }
            int largest = array[0];

            foreach (int num in array)
            {
                if (num > largest)
                {
                    largest = num;
                }
            }

            return largest;
        }

        //5. Array is fixed in size, Once created size cannot be changed. List is Dynamic, changes size based on values in list.
        static void ListOperate()
        {
            List<string> names = new List<string> {"Karuturi", "Siva", "Karthik", "Trainer", "Samp"};

            Console.WriteLine("Names in the list:");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Printed with Generic Printer:"); GenericPrinter(names);
        }
        static void GenericPrinter<T>(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }

        //6. Serialization is used to write data into a single format.
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void SerializeDeserialize()
        {
            Person person = new Person { Name = "Karthik", Age = 22};

            string filePath = "C:/Users/karuturi.sivakarthik/OneDrive - Volaris Group/Documents/Sample.txt";
            SerializeToJson(person, filePath);

            Person deserializedPerson = DeserializeFromJson(filePath);
            Console.WriteLine($"Deserialized Person: Name = {deserializedPerson.Name}, Age = {deserializedPerson.Age}");
        }
        static void SerializeToJson(Person person, string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(person);
            File.WriteAllText(filePath, jsonString);
        }

        static Person DeserializeFromJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            Person person = JsonConvert.DeserializeObject<Person>(jsonString);
            return person;
        }

        //7. when try block is executed if possibility of any error the compiler uses code in catch block. irrespective of error or no error
        //      some block of code is to be executed at end of try block then finally is used.
        // Example is already used in Oops method Overloading

        //8. Async/await  using asynchronous execution OS runs Background tasks. 
        static async Task DelayAsync()
        {
            Console.WriteLine("Delay Started");

            await Task.Delay(2000);

            Console.WriteLine("Delay Ended after 2 seconds.");
        }

    }
}
