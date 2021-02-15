using System;
using System.Collections.Generic;
using System.Linq;
public class Parking
{
    public List<Car> cars = new List<Car>();

    public int Capacity { get; set; }

    public void AddCar(Car car)
    {
        bool carAlreadyIn = cars.Contains(car);
        if (carAlreadyIn)
        {
            Console.WriteLine("Car with that registration number, already exists!");
        }
        else
        {
            bool parkingFull = cars.Count() >= Capacity;
            if (parkingFull)
            {
                Console.WriteLine("Parking is full!");
            }
            else
            {
                cars.Add(car);
                Console.WriteLine($"Successfully added new car {car.Make} {car.RegistrationNumber}");
            }
        }
    }

    public void RemoveCar(string carRegistration)
    {
        bool carInParking = cars.Any(x => x.RegistrationNumber == carRegistration);
        if (!carInParking)
        {
            Console.WriteLine("Car with that registration number, doesn't exist!");
        }
        else
        {
            var removedCar = cars.Find(x => x.RegistrationNumber == carRegistration);
            cars.Remove(removedCar);
            Console.WriteLine($"Successfully removed {carRegistration}");
        }
    }

    public void GetCar(string carRegistration)
    {
        bool carExists = cars.Any(x => x.RegistrationNumber == carRegistration);
        if (carExists)
        {
            var searchedCar = cars.Find(x => x.RegistrationNumber == carRegistration);
            searchedCar.ToString();
        }
    }

    public void Count()
    {
        Console.WriteLine(this.Capacity);
    }
}