using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var inputCounts = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < inputCounts; i++)
        {
            var inputInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //{model}{ engineSpeed}{ enginePower}{ cargoWeight}{ cargoType}{ tire1Pressure}{ tire1Age}{ tire2Pressure}{ tire2Age}{ tire3Pressure}{ tire3Age}{ tire4Pressure}{ tire4Age}
           
            var model = inputInfo[0];

            var engineSpeed = int.Parse(inputInfo[1]);
            var enginePower = int.Parse(inputInfo[2]);
            var engine = new Engine(engineSpeed, enginePower);

            var cargoWeight = int.Parse(inputInfo[3]);
            var cargoType = inputInfo[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            var tires = new Tire[4];
            
            var firstTirePressure = double.Parse(inputInfo[5]);
            var firstTireAge = int.Parse(inputInfo[6]);
            var firstTire = new Tire(firstTireAge, firstTirePressure);
            tires[0] = firstTire;

            var secondTirePressure = double.Parse(inputInfo[7]);
            var secondTireAge = int.Parse(inputInfo[8]);
            var secondTire = new Tire(secondTireAge, secondTirePressure);
            tires[1] = secondTire;

            var thirdTirePressure = double.Parse(inputInfo[9]);
            var thirdTireAge = int.Parse(inputInfo[10]);
            var thirdTire = new Tire(thirdTireAge, thirdTirePressure);
            tires[2] = thirdTire;

            var fourthTirePressure = double.Parse(inputInfo[11]);
            var fourthTireAge = int.Parse(inputInfo[12]);
            var fourthTire = new Tire(fourthTireAge, fourthTirePressure);
            tires[3] = fourthTire;

            var currentCar = new Car(model, engine, cargo, tires);
            cars.Add(currentCar);
        }

        var command = Console.ReadLine();
        // command is either flamable or fragile = cargoType

        Func<Car, bool> cargoTypeSorter = SortCars(command);
        cars = cars.Where(x => cargoTypeSorter(x)).ToList();

        foreach (var car in cars)
        {
            Console.WriteLine(car.Model);
        }
    }

    public static Func<Car, bool> SortCars(string command)
    {
        if (command == "fragile")
        {
            //•	"fragile" - print all cars whose cargo is "fragile" with a tire, whose pressure is  < 1
            return x => (x.Cargo.Type == "fragile") && x.Tires.Any(p => p.Pressure < 1);
        }
        else //(command == "flamable")
        {
            //•	"flamable" - print all of the cars, whose cargo is "flamable" and have engine power > 250
            return x => (x.Cargo.Type == "flamable") && x.Engine.EnginePower > 250;
        }
    }
}