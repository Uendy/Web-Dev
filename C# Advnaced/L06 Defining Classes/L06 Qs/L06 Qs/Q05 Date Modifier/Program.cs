using System;
public class Program
{
    public static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var dateTime = new DateModifier(firstDate, secondDate);

        Console.WriteLine(dateTime.DayDifference(dateTime.FirstDate, dateTime.SecondDate));
    }
}