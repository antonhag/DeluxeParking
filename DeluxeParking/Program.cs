namespace DeluxeParking;

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        
        for (int i = 0; i < 3; i++)
        vehicles =  Helpers.RandomVehicle(vehicles);

        int index = 1;
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Plats{index}\t{vehicle.PrintVehicle()}");
            index++;
        }
        
        
    }
}