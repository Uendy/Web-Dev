using System;
public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; set; }

    public void Drive(double distance)
    {
        bool enoughFuel = this.FuelQuantity > this.FuelConsumption * distance;
        if (enoughFuel)
        {
            this.FuelQuantity -= (this.FuelConsumption * distance);
        }
        else
        {
            Console.WriteLine("Not enough fuel to perform this trip!");
        }
    }

    public string WhoAmI()
    {
        return $"Make: {this.Make} \nModel: {this.Model} \nYear: {this.Year} \nFuel: {this.FuelConsumption:f2}";
    }
}