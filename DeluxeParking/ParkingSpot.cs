namespace DeluxeParking;

public class ParkingSpot
{
    public List<Vehicle> VehiclesParked { get; set; } = new List<Vehicle>();
    public double AvailableCapacity { get; set; } = 1;
}