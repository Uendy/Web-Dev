using System.Text;
public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int HorsePower { get; set; }
    public string RegistrationNumber { get; set; }

    public Car(string make, string model, int horsePower, string registrationNumber)
    {
        this.Make = make;
        this.Model = model;
        this.HorsePower = horsePower;
        this.RegistrationNumber = registrationNumber;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Make: {Make}");
        sb.AppendLine($"Model: {Model}");
        sb.AppendLine($"HorsePower: {HorsePower}");
        sb.AppendLine($"RegistrationNumber: {RegistrationNumber}");

        return sb.ToString();
    }
}