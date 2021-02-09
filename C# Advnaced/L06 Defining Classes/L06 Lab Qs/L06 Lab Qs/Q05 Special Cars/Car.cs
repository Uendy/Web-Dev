public class Car
{
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }
    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; }
    public Engine Engine { get; }
    public Tire[] Tires { get; }

    public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
    {
        this.Make = make;
        this.Model = model;
        this.Year = year;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.Engine = engine;
        this.Tires = tires;
    }
}