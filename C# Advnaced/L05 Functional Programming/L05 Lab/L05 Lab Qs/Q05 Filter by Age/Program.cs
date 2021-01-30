using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var inputCount = int.Parse(Console.ReadLine());
        var listOfPeople = new List<Person>();
        for (int i = 0; i < inputCount; i++)
        {
            var input = Console.ReadLine().Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var person = new Person
            {
                Name = input[0],
                Age = int.Parse(input[1])
            };
            listOfPeople.Add(person);
        }

        var youngerOrOlder = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());
        var format = Console.ReadLine();

        Func<int, bool> tester = CreateTester(youngerOrOlder, age);
        Action<Person> writer = CreateWriter(format);

        foreach (var person in listOfPeople)
        {
            if (tester(person.Age))
            {
                writer(person);
            }
        }
    }

    public static Action<Person> CreateWriter(string format)
    {
        switch (format)
        {
            case "name":
                return x => Console.WriteLine($"{x.Name}");

            case "age":
                return x => Console.WriteLine($"{x.Age}");

            case "name age":
                return x => Console.WriteLine($"{x.Name} - {x.Age}");

            default:
                return null;
        }
    }

    public static Func<int, bool> CreateTester(string youngerOrOlder, int age)
    {
        switch (youngerOrOlder)
        {
            case "younger":
                return x => x < age;

            case "older":
                return x => x >= age;

            default:
                return null;
        }
    }
}