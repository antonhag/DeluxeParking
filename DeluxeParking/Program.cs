namespace DeluxeParking;

class Program
{
    static void Main(string[] args)
    {
        int totalParkingSpots = 15;
        
        ParkingGarage parkingGarage = new(totalParkingSpots);
        parkingGarage.RunGarage();
    }
}