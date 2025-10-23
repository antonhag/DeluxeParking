namespace DeluxeParking;

public class Bus : Vehicle
{
    public int NumberOfPassengers { get; set; }

    public Bus(string licensePlateNumber, string vehicleColor, int numberOfPassengers) : base(licensePlateNumber, vehicleColor)
    {
        NumberOfPassengers = numberOfPassengers;
    }
}