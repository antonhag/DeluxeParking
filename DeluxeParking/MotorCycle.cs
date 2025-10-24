namespace DeluxeParking;

public class MotorCycle : Vehicle
{
    public string Brand { get; set; }

    public MotorCycle(string licensePlateNumber, string vehicleColor, double vehicleSize, string brand) : base(licensePlateNumber, vehicleColor,  vehicleSize)
    {
        Brand = brand;
    }
    
    public override string PrintVehicle()
    {
        string vehicleInfo = $"MC\t{LicensePlateNumber}\t{VehicleColor}\t{Brand}";
        return vehicleInfo;
    }
}