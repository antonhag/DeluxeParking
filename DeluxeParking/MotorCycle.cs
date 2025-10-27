namespace DeluxeParking;

public class MotorCycle : Vehicle
{
    public string Brand { get; set; }

    public MotorCycle(string licensePlateNumber, string vehicleColor, string vehicleName, double vehicleSize, string brand) : base(licensePlateNumber, vehicleColor, vehicleName, vehicleSize)
    {
        Brand = brand;
        VehicleName = vehicleName;
    }
    
    public override string PrintVehicle()
    {
        string vehicleInfo = $"MC\t{LicensePlateNumber}\t{VehicleColor}\t{Brand}";
        return vehicleInfo;
    }
}