using System;

public class Day
{
    public int DayOfMonth { get; set; }

    public Day(int dayOfMonth)
    {
        DayOfMonth = dayOfMonth;
    }

    public override string ToString()
    {
        return $"{DayOfMonth}";
    }
}

public class Month
{
    public int MonthNumber { get; set; }

    public Month(int monthNumber)
    {
        MonthNumber = monthNumber;
    }

    public override string ToString()
    {
        return $"{MonthNumber}";
    }
}

public class Year
{
    public int YearNumber { get; set; }

    public Year(int yearNumber)
    {
        YearNumber = yearNumber;
    }

    public override string ToString()
    {
        return $"{YearNumber}";
    }
}

public class Date : Year
{
    public Month Month { get; set; }
    public Day Day { get; set; }

    public Date(int year, int month, int day) : base(year)
    {
        Month = new Month(month);
        Day = new Day(day);
    }

    public string GetDayOfWeek()
    {
        return "Day of the week"; 
    }

    public int GetDaysDifference(Date otherDate)
    {
        int daysInMonth = 30; 
        int thisDays = this.Day.DayOfMonth + this.Month.MonthNumber * daysInMonth + this.YearNumber * 365;
        int otherDays = otherDate.Day.DayOfMonth + otherDate.Month.MonthNumber * daysInMonth + otherDate.YearNumber * 365;
        return Math.Abs(otherDays - thisDays);
    }

    public int GetMonthsDifference(Date otherDate)
    {
        int monthsInYear = 12;
        int thisMonths = this.Month.MonthNumber + this.YearNumber * monthsInYear;
        int otherMonths = otherDate.Month.MonthNumber + otherDate.YearNumber * monthsInYear;
        return Math.Abs(otherMonths - thisMonths);
    }

    public int GetYearsDifference(Date otherDate)
    {
        return Math.Abs(otherDate.YearNumber - this.YearNumber);
    }

    public override string ToString()
    {
        return $"{Day}.{Month}.{YearNumber}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first date (year, month, day):");
        string[] input1 = Console.ReadLine().Split();
        int year1 = int.Parse(input1[0]);
        int month1 = int.Parse(input1[1]);
        int day1 = int.Parse(input1[2]);
        Date date1 = new Date(year1, month1, day1);

        Console.WriteLine("Enter the second date (year, month, day):");
        string[] input2 = Console.ReadLine().Split();
        int year2 = int.Parse(input2[0]);
        int month2 = int.Parse(input2[1]);
        int day2 = int.Parse(input2[2]);
        Date date2 = new Date(year2, month2, day2);

        Console.WriteLine($"Difference in years: {date1.GetYearsDifference(date2)}");
        Console.WriteLine($"Difference in months: {date1.GetMonthsDifference(date2)}");
        Console.WriteLine($"Difference in days: {date1.GetDaysDifference(date2)}");
    }
}
