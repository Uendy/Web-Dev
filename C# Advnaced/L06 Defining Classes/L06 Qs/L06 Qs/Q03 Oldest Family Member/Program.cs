using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var inputCounts = int.Parse(Console.ReadLine());

        var family = new Family();
        for (int i = 0; i < inputCounts; i++)
        {
            var currentMemberInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var name = currentMemberInfo[0];
            var age = int.Parse(currentMemberInfo[1]);

            var member = new Person(name, age);
            family.AddMember(member);
        }

        var olderMember = family.ReturnOlder();
        Console.WriteLine($"{olderMember.Name} {olderMember.Age}");
    }
}