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

            }
            else
            {
                cars.Add(car);
            }
        }
    }
}