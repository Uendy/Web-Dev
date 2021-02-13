public class Car
{
    public string CarModel { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public Car(string carModel, Engine engine)
    {
        this.CarModel = carModel;
        this.Engine = engine;
    }

    public Car(string carModel, Engine engine, int weight)
        : this(carModel, engine)
    {
        this.Weight = weight;
    }

    public Car(string carModel, Engine engine, string color)
        : this(carModel, engine)
    {
        this.Color = color;
    }

    public Car(string carModel, Engine engine, int weight, string color)
        : this(carModel, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }
}