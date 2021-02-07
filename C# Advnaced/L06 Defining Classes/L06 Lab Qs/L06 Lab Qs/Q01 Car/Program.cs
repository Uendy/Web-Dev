using System;
public class Program
{
    public static void Main()
    {
        var car = new Car();

        car.Make = "VW";
        car.Model = "MK3";
        car.Year = 1993;

        Console.WriteLine($"Make: {car.Make}");
        Console.WriteLine($"Model: {car.Model}");
        Console.WriteLine($"Year: {car.Year}");
    }
}