using System.Collections;

namespace DeluxeParking;

public class ParkingGarage
{
    public List<Vehicle> Vehicles { get; set; }
    public Vehicle[,] Garage { get; set; }

    public ParkingGarage()
    {
        Vehicles = new List<Vehicle>();
        Garage = new Vehicle[7, 2];
        
    }

    public void RunGarage()
    {
        while (true)
        {
            Console.WriteLine("Välkommen till parkeringshuset!");
            Console.WriteLine("\n1. För att parkera fordonet");
            Console.WriteLine("2. För att checka ut fordonet");
            Console.WriteLine("3. För att se alla fordon i parkeringshuset");
        
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    AddVehicleToGarage();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();

                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    PrintGarage();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ogiltigt val!");
                    break;
            }
        }
    }
    
        
    public void AddVehicleToGarage()
    {
        Vehicle vehicle = Helpers.RandomVehicle();
        
        Vehicles.Add(vehicle);
        
        for (int i = 0; i < Garage.GetLength(0); i++)
        {
            for (int j = 0; j < Garage.GetLength(1); j++)
            {
                if (Garage[i, j] == null)
                {
                    Garage[i,j] = vehicle;
                    Console.Clear();
                    Console.WriteLine($"Fordon {vehicle.LicensePlateNumber} parkerades på plats [{i},{j}]");
                    return; // Avslutar metoden direkt.
                }
            }
        }
        Console.WriteLine("Garaget är fullt!");
    }

    public void RemoveVehicleFromGarage()
    {
        
    }

    public void PrintGarage()
    {
        Console.WriteLine("Alla fordon i parkerinshuset just nu: ");

        int index = 1;
        foreach (Vehicle vehicle in Garage)
        {
            if (vehicle != null)
            {
                Console.WriteLine($"Plats {index}:\t{vehicle.PrintVehicle()}");
            }
            else
            {
                Console.WriteLine($"Plats {index}: [Tom]");
            }
            index++;
        }
    }
    
}