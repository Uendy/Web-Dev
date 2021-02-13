using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var engineCount = int.Parse(Console.ReadLine());
        var engines = new List<Engine>();

        for (int i = 0; i < engineCount; i++)
        {
            var engineInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var model = engineInfo[0];
            var power = int.Parse(engineInfo[1]);

            if (engineInfo.Count() == 2) // only model and power are given:
            {
                var engine = new Engine(model, power);
                engines.Add(engine);
            }
            else if (engineInfo.Count() == 3) // model power and (either: displacement or efficiency) are given:
            {
                // See which is given and create the object with the right constructor:
                bool displacementIsGiven = int.TryParse(engineInfo[2], out int displacement);
                if (displacementIsGiven)
                {
                    var engine = new Engine(model, power, displacement);
                    engines.Add(engine);
                }
                else // efficiency is given:
                {
                    var efficiency = engineInfo[2];

                    var engine = new Engine(model, power, efficiency);
                    engines.Add(engine);
                }
            }
            else // all is given:
            {
                var displacement = int.Parse(engineInfo[2]);
                var efficiency = engineInfo[3];

                var engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }
        }

        var carsCount = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            var carInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var carModel = carInfo[0];
            var engineModel = carInfo[1];
            var engine = engines.Find(x => x.EngineModel == engineModel); // Find the matching engine

            if (carInfo.Count() == 2) //only model and engine are given, so create object
            {
                var car = new Car(carModel, engine);
                cars.Add(car);
            }
            else if (carInfo.Count() == 3) // model and engine and (either weight or color) find which and create object
            {
                // Find out if car has weight or color:
                bool weightIsGiven = int.TryParse(carInfo[2], out int weight);
                if (weightIsGiven)
                {
                    var car = new Car(carModel, engine, weight);
                    cars.Add(car);
                }
                else // color is given:
                {
                    var color = carInfo[2];

                    var car = new Car(carModel, engine, color);
                    cars.Add(car);
                }
            }
            else // all 4 parameters are given:
            {
                var weight = int.Parse(carInfo[2]);
                var color = carInfo[3];

                var car = new Car(carModel, engine, weight, color);
                cars.Add(car);
            }
        }

        foreach (var car in cars)
        {
            var carIndentation = "  ";
            var engineIndentation = "       ";

            Console.WriteLine($"{car.CarModel}:");
            Console.WriteLine($"{carIndentation}{car.Engine.EngineModel}:");
            Console.WriteLine($"{engineIndentation}Power: {car.Engine.Power}");

            Console.Write($"{engineIndentation}Displacement: ");
            if (car.Engine.Displacement == 0)
            {
                Console.WriteLine("n/a");
            }
            else
            {
                Console.WriteLine(car.Engine.Displacement);
            }

            Console.Write($"{engineIndentation}Efficiency: ");
            if (car.Engine.Efficiency == null)
            {
                Console.WriteLine("n/a");
            }
            else
            {
                Console.WriteLine(car.Engine.Efficiency);
            }

            Console.Write($"{carIndentation}Weight: ");
            if (car.Weight == 0)
            {
                Console.WriteLine("n/a");
            }
            else
            {
                Console.WriteLine(car.Weight);
            }

            Console.Write($"{carIndentation}Color: ");
            if (car.Color == null)
            {
                Console.WriteLine("n/a");
            }
            else
            {
                Console.WriteLine(car.Color);
            }
        }
    }
}