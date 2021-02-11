using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var inputCount = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < inputCount; i++)
        {
            var currentCarInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var model = currentCarInfo[0];
            var fuelAmount = double.Parse(currentCarInfo[1]);
            var fuelConsumption = double.Parse(currentCarInfo[2]);

            var currentCar = new Car(model, fuelAmount, fuelConsumption);

            cars.Add(currentCar);
        }

        string driveInput;
        while ((driveInput = Console.ReadLine()) != "End")
        {
            var driveInputInfo = driveInput.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var model = driveInputInfo[1];
            var distance = int.Parse(driveInputInfo[2]);

            bool carExists = cars.Any(x => x.Model == model);
            if (carExists)
            {
                var currentCar = cars.Where(x => x.Model == model).First();

                currentCar.DriveCar(distance);
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
        }
    }
}