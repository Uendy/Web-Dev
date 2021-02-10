using System;
using System.Globalization;
public class DateModifier
{
    public string FirstDate { get; set; }
    public string SecondDate { get; set; }

    public DateModifier(string firstDate, string secondDate)
    {
        this.FirstDate = firstDate;
        this.SecondDate = secondDate;
    }

    public double DayDifference(string firstDate, string secondDate)
    {
        var firstDateTime = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDateTime = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

        var interval = firstDateTime - secondDateTime;
        var days = Math.Abs(interval.TotalDays);
        return days;
    }
}