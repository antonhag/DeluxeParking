namespace DeluxeParking;

public class ParkingSpot
{
    public List<Vehicle> VehiclesParked { get; set; }
    public double AvailableCapacity { get; set; }
    
    public ParkingSpot()
    {
        VehiclesParked = new List<Vehicle>();
        AvailableCapacity = 1;
    }
}