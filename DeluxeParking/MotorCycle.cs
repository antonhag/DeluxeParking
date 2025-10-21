namespace DeluxeParking;

public class MotorCycle : Vehicle
{
    public string Brand { get; set; }

    public MotorCycle(int licensePlateNumber, string vehicleColor, string brand) : base(licensePlateNumber, vehicleColor)
    {
        Brand = brand;
    }
}