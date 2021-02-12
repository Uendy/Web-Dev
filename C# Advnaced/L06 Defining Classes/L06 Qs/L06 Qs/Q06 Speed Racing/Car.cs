using System;
public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKilometer { get; set; }
    public double TravelledDistance { get; set; }

    public Car(string model, double fuelAMount, double fuelConsumptionPerKilometer)
    {
        this.Model = model;
        this.FuelAmount = fuelAMount;
        this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        this.TravelledDistance = 0;
    }

    public void DriveCar(double distance)
    {
        var fuelNeeded = distance * FuelConsumptionPerKilometer;
        bool enoughFuel = FuelAmount >= fuelNeeded;
        if (enoughFuel)
        {
            FuelAmount -= fuelNeeded;
            TravelledDistance += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}