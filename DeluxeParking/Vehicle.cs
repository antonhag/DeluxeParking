namespace DeluxeParking;

public abstract class Vehicle // Hade redan skapat basklassen Vehicle innan interface genomgången, därav får den bli abstract istället
{
    public string LicensePlateNumber { get; set; }
    public string VehicleColor { get; set; }
    public string VehicleName { get; set; }
    public double VehicleSize { get; set; }

    protected Vehicle(string licensePlateNumber, string vehicleColor, string vehicleName, double vehicleSize)
    {
        LicensePlateNumber = licensePlateNumber;
        VehicleColor = vehicleColor;
        VehicleName = vehicleName;
        VehicleSize = vehicleSize;
    }

    public abstract string PrintVehicle();
}