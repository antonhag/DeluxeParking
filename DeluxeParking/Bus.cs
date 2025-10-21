namespace DeluxeParking;

public class Bus : Vehicle
{
    public int NumberOfPassengers { get; set; }

    public Bus(int licensePlateNumber, string vehicleColor, int numberOfPassengers) : base(licensePlateNumber, vehicleColor)
    {
        NumberOfPassengers = numberOfPassengers;
    }
}