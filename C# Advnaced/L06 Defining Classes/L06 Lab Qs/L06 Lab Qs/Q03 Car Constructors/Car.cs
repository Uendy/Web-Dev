public class Car
{
    // Initialize Fields:
    private string make;
    private string model;
    private int year;
    private double fuelQuantity;
    private double fuelConsumption;

    // Fill public properties
    //public string Make
    //{
    //    get
    //    {
    //        return this.make;
    //    }
    //    set
    //    {
    //        this.make = value;
    //    }
    //}

    //public string Model
    //{
    //    get
    //    {
    //        return this.model;
    //    }
    //    set
    //    {
    //        this.model = value;
    //    }

    //}

    //public int Year
    //{
    //    get
    //    {
    //        return this.year;
    //    }
    //    set
    //    {
    //        this.year = value;
    //    }
    //}

    //public double FuelQuantity
    //{
    //    get
    //    {
    //        return this.fuelQuantity;
    //    }
    //    set
    //    {
    //        this.fuelQuantity = value;
    //    }
    //}

    //public double FuelConsumption
    //{
    //    get
    //    {
    //        return this.fuelConsumption;
    //    }
    //    set
    //    {
    //        this.fuelConsumption = value;
    //    }
    //}

    // Constructors:

    public Car()
    { 
    
    }

    public Car(string Make, string Model, int Year)
    {
        this.make = Make;
        this.model = Model;
        this.year = Year;
    }

    public Car(string Make, string Model, int Year, double FuelQuantity, double FuelConsumption)
        : this(Make, Model, Year)
    {
        this.fuelQuantity = FuelQuantity;
        this.fuelConsumption = FuelConsumption;
    }
}