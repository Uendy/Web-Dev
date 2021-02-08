public class Engine
{
    public int HorsePower { get; }
    public double CubicCapacity { get; }

    public Engine(int horsePower, double cubicCapacity)
    {
        this.HorsePower = horsePower;
        this.CubicCapacity = cubicCapacity;
    }
}