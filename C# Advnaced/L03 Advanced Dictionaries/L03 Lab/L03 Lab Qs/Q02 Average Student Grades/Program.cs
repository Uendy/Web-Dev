using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Initialize dict:
        var grades = new Dictionary<string, List<decimal>>(); // Key = studentName, Value = List<decimal>, of grades

        // Reading inputs:
        int inputCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < inputCount; i++)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var studentName = input[0];
            var grade = decimal.Parse(input[1]);

            // Update grades:
            bool newStudent = !grades.ContainsKey(studentName);
            if (newStudent)
            {
                grades[studentName] = new List<decimal>();
            }
            grades[studentName].Add(grade);
        }

        // Formatting, Averaging and Printing:
        foreach (var student in grades)
        {
            Console.Write($"{student.Key} -> ");
            var allGrades = string.Join(" ", student.Value.Select(x => x.ToString("F2")));
            Console.WriteLine($"{allGrades} (avg: {student.Value.Average():f2})");
        }
    }
}