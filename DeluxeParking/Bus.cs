namespace DeluxeParking;

public class Bus : Vehicle
{
    private int NumberOfPassengers { get; set; }

    public Bus(string licensePlateNumber, string color, string name, double size, int numberOfPassengers) : base(licensePlateNumber, color, name, size)
    {
        NumberOfPassengers = numberOfPassengers;
    }
    
    public override string PrintVehicle()
    {
        string vehicleInfo = $"\tBuss\t{LicensePlateNumber}\t{Color}\t{NumberOfPassengers}";
        return vehicleInfo;
    }
}