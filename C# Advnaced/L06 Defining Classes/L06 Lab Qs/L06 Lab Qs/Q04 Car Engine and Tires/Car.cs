public class Car
{
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }
    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; set; }
    public Engine Engine { get; }
    public Tire[] Tires { get; set; }

    public Car()
    { 
    
    }

    public Car(string make, string model, int year)
    {
        this.Make = make;
        this.Model = model;
        this.Year = year;
    }

    public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        :this(make, model, year)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        : this(make, model, year, fuelQuantity, fuelConsumption)
    {
        this.Engine = engine;
        this.Tires = tires;
    }
}