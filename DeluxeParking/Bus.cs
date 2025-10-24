namespace DeluxeParking;

public class Bus : Vehicle
{
    public int NumberOfPassengers { get; set; }

    public Bus(string licensePlateNumber, string vehicleColor, double vehicleSize, int numberOfPassengers) : base(licensePlateNumber, vehicleColor, vehicleSize)
    {
        NumberOfPassengers = numberOfPassengers;
    }
    
    public override string PrintVehicle()
    {
        string vehicleInfo = $"Buss\t{LicensePlateNumber}\t{VehicleColor}\t{NumberOfPassengers}";
        return vehicleInfo;
    }
}