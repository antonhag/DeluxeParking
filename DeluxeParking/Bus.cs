namespace DeluxeParking;

public class Bus : Vehicle
{
    private int NumberOfPassengers { get; set; }

    public Bus(string licensePlateNumber, string vehicleColor, string vehicleName, double vehicleSize, int numberOfPassengers) : base(licensePlateNumber, vehicleColor, vehicleName, vehicleSize)
    {
        NumberOfPassengers = numberOfPassengers;
        VehicleName = vehicleName;
    }
    
    public override string PrintVehicle()
    {
        string vehicleInfo = $"Buss\t{LicensePlateNumber}\t{VehicleColor}\t{NumberOfPassengers}";
        return vehicleInfo;
    }
}