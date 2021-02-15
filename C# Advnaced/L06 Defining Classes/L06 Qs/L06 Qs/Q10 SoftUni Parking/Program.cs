using System;
public class Program
{
    public static void Main()
    {
        var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
        var car2 = new Car("Audi", "A3", 110, "EB8787MN");

        Console.WriteLine(car.ToString());

        var parking = new Parking();
        parking.Capacity = 5;
        parking.AddCar(car);

        parking.AddCar(car);

        parking.AddCar(car2);

        parking.GetCar("EB8787MN");

        parking.RemoveCar("EB8787MN");

        parking.Count();
    }
}