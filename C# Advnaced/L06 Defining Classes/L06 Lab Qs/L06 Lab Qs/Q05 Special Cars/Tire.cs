﻿public class Tire
{
    public int Year { get; }
    public double Pressure { get; set; }

    public Tire(int year, double pressure)
    {
        this.Year = year;
        this.Pressure = pressure;
    }
}