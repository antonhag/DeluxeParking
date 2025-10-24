namespace DeluxeParking;

class Program
{
    static void Main(string[] args)
    {
        ParkingGarage parkingGarage = new(15);
        parkingGarage.RunGarage();
    }
}