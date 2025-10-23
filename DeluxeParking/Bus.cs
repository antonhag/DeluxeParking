namespace DeluxeParking;

public class Bus : Vehicle
{
    public int NumberOfPassengers { get; set; }

    public Bus(string licensePlateNumber, string vehicleColor, int numberOfPassengers) : base(licensePlateNumber, vehicleColor)
    {
        NumberOfPassengers = numberOfPassengers;
    }
    
    public override string PrintVehicle()
    {
        string vehicleInfo = $"Bil\t{LicensePlateNumber}\t{VehicleColor}\t{NumberOfPassengers}";
        return vehicleInfo;
    }
}