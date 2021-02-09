using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var tires = new List<Tire[]>();
        string tireInput;
        while ((tireInput = Console.ReadLine()) != "No more tires")
        {
            var tireInfo = tireInput.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var currentTires = new Tire[4];
            for (int i = 0; i < 8; i+= 2) // we will get 4 tires with Year and pressure
            {
                var year = int.Parse(tireInfo[i]);
                var pressure = double.Parse(tireInfo[i + 1]);

                var currentTire = new Tire(year, pressure);
                currentTires[i / 2] = currentTire;
            }
            tires.Add(currentTires);
        }

        var engines = new List<Engine>();
        string engineInput;
        while ((engineInput = Console.ReadLine()) != "Engines done")
        {
            var engineInfo = engineInput.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int horsePower = int.Parse(engineInfo[0]);
            double cubicCapacity = double.Parse(engineInfo[1]);

            var currentEngine = new Engine(horsePower, cubicCapacity);
            engines.Add(currentEngine);
        }

        var cars = new List<Car>();
        string carInput;
        while ((carInput = Console.ReadLine()) != "Show special")
        {
            var carInfo = carInput.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var make = carInfo[0];
            var model = carInfo[1];
            var year = int.Parse(carInfo[2]);
            var fuelCapacity = double.Parse(carInfo[3]);
            var fuelConsumption = double.Parse(carInfo[4]);
            var carEngine = engines[int.Parse(carInfo[5])];
            var carTires = tires[int.Parse(carInfo[6])];

            var currentCar = new Car(make, model, year, fuelCapacity, fuelConsumption, carEngine, carTires);
            cars.Add(currentCar);
        }

        var specialCars = cars
            .Where(x => x.Year >= 2017)
            .Where(y => y.Engine.HorsePower >= 330)
            .Where(z => z.Tires.Sum(p => p.Pressure) >= 9 && z.Tires.Sum(p => p.Pressure) <= 10)
            .ToList();

        foreach (var car in specialCars)
        {
            Console.WriteLine($"Make: {car.Make}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Year: {car.Year}");
            Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");

            car.FuelQuantity = car.FuelQuantity - (car.FuelConsumption * 0.2);
            Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
        }
    }
}