namespace DeluxeParking;

public class Vehicle
{
    public string LicensePlateNumber { get; set; }
    public string VehicleColor { get; set; }

    public Vehicle(string licensePlateNumber, string vehicleColor)
    {
        LicensePlateNumber = licensePlateNumber;
        VehicleColor = vehicleColor;
    }
}