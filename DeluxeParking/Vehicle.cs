namespace DeluxeParking;

public class Vehicle
{
    public int LicensePlateNumber { get; set; }
    public string VehicleColor { get; set; }

    public Vehicle(int licensePlateNumber, string vehicleColor)
    {
        LicensePlateNumber = licensePlateNumber;
        VehicleColor = vehicleColor;
    }
}