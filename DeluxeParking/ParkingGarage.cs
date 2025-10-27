using System.Collections;

namespace DeluxeParking;

public class ParkingGarage
{
    public ParkingSpot[] Garage { get; set; }

    public ParkingGarage(int totalSpots)
    {
        Garage = new ParkingSpot[totalSpots];

        for (int i = 0; i < totalSpots; i++)
        {
            Garage[i] = new ParkingSpot();
        }
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
                    RemoveVehicleFromGarage();
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

        for (int i = 0; i < Garage.Length; i++)
        {
            if (vehicle is Bus)
            {
                if (i + 1 < Garage.Length && Garage[i].AvailableCapacity >= 1 && Garage[i + 1].AvailableCapacity >= 1)
                {
                    Garage[i].VehiclesParked.Add(vehicle);
                    Garage[i + 1].VehiclesParked.Add(vehicle);
                    Garage[i].AvailableCapacity -= 1;
                    Garage[i + 1].AvailableCapacity -= 1;
                    Console.WriteLine(
                        $"Bussen med registreringsnummer {vehicle.LicensePlateNumber} parkerades på plats {i + 1}-{i + 2}");
                    return;
                }
            }
            else
            {
                if (Garage[i].AvailableCapacity >= vehicle.VehicleSize)
                {
                    Garage[i].VehiclesParked.Add(vehicle);
                    Garage[i].AvailableCapacity -= vehicle.VehicleSize;
                    Console.WriteLine($"{vehicle.VehicleName} med registreringsnummer {vehicle.LicensePlateNumber} parkerades på plats {i + 1}");
                    return;
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
        Console.WriteLine("Alla fordon i parkeringshuset just nu:\n");

        int index = 1;
        for (int i = 0; i < Garage.Length; i++)
        {
            ParkingSpot spot = Garage[i];

            if (spot.VehiclesParked.Count > 0)
            {
                foreach (Vehicle vehicle in spot.VehiclesParked)
                {
                    // SE ÖVER
                    if (vehicle is Bus && (i == 0 || !Garage[i - 1].VehiclesParked.Contains(vehicle))) // Visa buss en gång per buss per plats, annars skriver den ut samma buss två gånger
                    {
                        Console.WriteLine($"Plats {index}-{index + 1}: {vehicle.PrintVehicle()}");
                    }
                    else if (!(vehicle is Bus))
                    {
                        Console.WriteLine($"Plats {index}: {vehicle.PrintVehicle()}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Plats {index}: [Tom]");
            }
            index++;
        }
    }
}