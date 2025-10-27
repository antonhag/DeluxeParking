namespace DeluxeParking;

public abstract class Vehicle
{
    public string LicensePlateNumber { get; set; }
    public string VehicleColor { get; set; }
    public double VehicleSize { get; set; }

    protected Vehicle(string licensePlateNumber, string vehicleColor, double vehicleSize)
    {
        LicensePlateNumber = licensePlateNumber;
        VehicleColor = vehicleColor;
        VehicleSize = vehicleSize;
    }

    public abstract string PrintVehicle();
}