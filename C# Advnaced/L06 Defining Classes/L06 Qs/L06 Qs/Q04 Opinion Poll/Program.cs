using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var inputCount = int.Parse(Console.ReadLine());
        var people = new List<Person>();
        for (int i = 0; i < inputCount; i++)
        {
            var personInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var name = personInfo[0];
            var age = int.Parse(personInfo[1]);

            var person = new Person(name, age);
            people.Add(person);
        }

        var selectedPeople = people.Where(x => x.Age >= 30).OrderBy(y => y.Name).ToList();
        foreach (var person in selectedPeople)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}