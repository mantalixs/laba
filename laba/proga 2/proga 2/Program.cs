using System;
using System.Collections.Generic;
using System.Linq;

public class Vessel
{
    public string Name { get; set; }
    public int Year { get; set; }
    public double FuelConsumption { get; set; }

    public Vessel(string name, int year, double fuelConsumption)
    {
        Name = name;
        Year = year;
        FuelConsumption = fuelConsumption;
    }
}

public class TankerShip : Vessel
{
    public double CargoCapacity { get; set; }

    public TankerShip(string name, int year, double fuelConsumption, double cargoCapacity)
        : base(name, year, fuelConsumption)
    {
        CargoCapacity = cargoCapacity;
    }
}

public class CargoShip : Vessel
{
    public double CargoCapacity { get; set; }

    public CargoShip(string name, int year, double fuelConsumption, double cargoCapacity)
        : base(name, year, fuelConsumption)
    {
        CargoCapacity = cargoCapacity;
    }
}

public class Carrier
{
    public List<Vessel> Vessels { get; set; }

    public Carrier()
    {
        Vessels = new List<Vessel>();
    }

    public void AddVessel(Vessel vessel)
    {
        Vessels.Add(vessel);
    }

    public double CalculateTotalCargoCapacity()
    {
        return Vessels.Sum(vessel => (vessel as TankerShip)?.CargoCapacity ?? 0 + (vessel as CargoShip)?.CargoCapacity ?? 0);
    }

    public double CalculateTotalFuelConsumption()
    {
        return Vessels.Sum(vessel => vessel.FuelConsumption);
    }

    public void SortVesselsByFuelConsumption()
    {
        Vessels.Sort((x, y) => x.FuelConsumption.CompareTo(y.FuelConsumption));
    }

    public List<Vessel> FindVesselsByYearRange(int startYear, int endYear)
    {
        return Vessels.Where(vessel => vessel.Year >= startYear && vessel.Year <= endYear).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Carrier carrier = new Carrier();

        carrier.AddVessel(new TankerShip("Tanker 1", 2000, 100, 5000));
        carrier.AddVessel(new TankerShip("Tanker 2", 1995, 150, 7000));
        carrier.AddVessel(new CargoShip("Cargo Ship 1", 2010, 80, 10000));
        carrier.AddVessel(new CargoShip("Cargo Ship 2", 2005, 90, 12000));

        Console.WriteLine($"Total cargo capacity of the carrier: {carrier.CalculateTotalCargoCapacity()} tons");
        Console.WriteLine($"Total fuel consumption of the carrier: {carrier.CalculateTotalFuelConsumption()} liters per hour");

        carrier.SortVesselsByFuelConsumption();

        List<Vessel> vesselsInRange = carrier.FindVesselsByYearRange(2000, 2010);
        Console.WriteLine("Vessels within the specified year range:");
        foreach (var vessel in vesselsInRange)
        {
            Console.WriteLine($"Name: {vessel.Name}, Year: {vessel.Year}");
        }
    }
}
