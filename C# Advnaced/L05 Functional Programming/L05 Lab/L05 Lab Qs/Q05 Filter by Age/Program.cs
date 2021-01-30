using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading inputs:
        var inputs = int.Parse(Console.ReadLine());

        var listOfPeople = new List<Person>();
        for (int i = 0; i < inputs; i++)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var person = new Person()
            {
                Name = input[0],
                Age = int.Parse(input[1])
            };

            listOfPeople.Add(person);
        }


        var ageFilter = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        Func<int, bool> tester = CheckAge(ageFilter, age);

        listOfPeople.Where(CheckAge).ToList();
    }

    public static Func<int, bool> CheckAge(string agefilter, int age)
    {
        switch (agefilter)
        {
            case "younger": return x => x < age;
            case "older": return x => x >= age;
            default: return null;
        }
    }
}