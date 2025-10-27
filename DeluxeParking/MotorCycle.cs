namespace DeluxeParking;

public class MotorCycle : Vehicle
{
    private string Brand { get; set; }

    public MotorCycle(string licensePlateNumber, string color, string name, double size, string brand) : base(licensePlateNumber, color, name, size)
    {
        Brand = brand;
    }
    
    public override string PrintVehicle()
    {
        string vehicleInfo = $"\tMC\t{LicensePlateNumber}\t{Color}\t{Brand}";
        return vehicleInfo;
    }
}