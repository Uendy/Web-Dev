public class Engine
{
    public int HorsePower { get; }
    public double CubicQuantity { get; }

    public Engine(int horsePower, double cubicQuantity)
    {
        this.HorsePower = horsePower;
        this.CubicQuantity = cubicQuantity;
    }
}