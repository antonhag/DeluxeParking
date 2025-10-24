namespace DeluxeParking;

public class Vehicle
{
    public string LicensePlateNumber { get; set; }
    public string VehicleColor { get; set; }
    public double VehicleSize { get; set; }

    public Vehicle(string licensePlateNumber, string vehicleColor, double vehicleSize)
    {
        LicensePlateNumber = licensePlateNumber;
        VehicleColor = vehicleColor;
        VehicleSize = vehicleSize;
    }

    public virtual string PrintVehicle()
    {
        string vehicleInfo = "";
        
        return vehicleInfo;
    }
}