public class Engine
{
    public string EngineModel { get; set; }
    public int Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine (string engineModel, int power)
    {
        this.EngineModel = engineModel;
        this.Power = power;
    }

    public Engine(int displacement)
        : this(engineModel, power)
    {
        this.Displacement = displacement;
    }
}