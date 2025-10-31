using System.Collections;

namespace DeluxeParking;

public class ParkingGarage
{
    private ParkingSpot[] Garage { get; set; }
    private double ParkingFee { get; set; } = 1.5;

    public ParkingGarage(int totalSpots)
    {
        Garage = new ParkingSpot[totalSpots];

        for (int i = 0; i < totalSpots; i++)
        {
            Garage[i] = new ParkingSpot(); // Skapar en ny tom parkeringsruta på varje position i arrayen
        }
    }

    public void RunGarage()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till parkeringshuset!");
            Console.WriteLine("\n1. För att parkera fordonet");
            Console.WriteLine("2. För att checka ut fordonet");
            Console.WriteLine("3. För att se alla fordon i parkeringshuset");
            Console.WriteLine($"\nParkeringsavgiften för kortidsparkering är: {ParkingFee} kr/min.");
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
                    Helpers.PrintGarage(Garage);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ogiltigt val!");
                    break;
            }
        }
    }

    private void AddVehicleToGarage()
    {
        Vehicle vehicle = Helpers.RandomVehicle();

        for (int i = 0; i < Garage.Length; i++)
        {
            if (vehicle is Bus)
            {
                if (i + 1 < Garage.Length && Garage[i].VehiclesParked.Count == 0 &&
                    Garage[i + 1].VehiclesParked.Count == 0)
                {
                    Garage[i].VehiclesParked.Add(vehicle);
                    Garage[i + 1].VehiclesParked.Add(vehicle);
                    Garage[i].AvailableCapacity = 0; // = 0 eftersom platsen blir full
                    Garage[i + 1].AvailableCapacity = 0;
                    Console.Clear();
                    Console.WriteLine(
                        $"{vehicle.Name} med registreringsnummer {vehicle.LicensePlateNumber} parkerades på plats {i + 1}-{i + 2}");
                    Thread.Sleep(3000);
                    return;
                }
            }
            else
            {
                if (Garage[i].AvailableCapacity >= vehicle.Size)
                {
                    Garage[i].VehiclesParked.Add(vehicle);
                    Garage[i].AvailableCapacity -= vehicle.Size;
                    Console.Clear();
                    Console.WriteLine(
                        $"{vehicle.Name} med registreringsnummer {vehicle.LicensePlateNumber} parkerades på plats {i + 1}");
                    Thread.Sleep(3000);
                    return;
                }
            }
        }

        Console.Clear();
        Console.WriteLine("Garaget är fullt!");
        Thread.Sleep(2000);
    }

    private void RemoveVehicleFromGarage()
    {
        Console.Write("Skriv in registreringsnumret för fordonet du vill checka ut: ");
        string
            input = Console.ReadLine()
                .ToUpper(); // ToUpper för att användaren ska slippa skriva in registreringsnumret med stora bokstäver

        bool vehicleFound = false;
        bool garageEmpty = true;

        for (int i = 0; i < Garage.Length; i++)
        {
            ParkingSpot spot = Garage[i];

            if (spot.VehiclesParked.Count > 0)
            {
                garageEmpty = false;

                foreach (Vehicle vehicle in spot.VehiclesParked)
                {
                    if (vehicle.LicensePlateNumber == input)
                    {
                        Console.Clear();
                        if (vehicle is Bus)
                        {
                            for (int j = 0;
                                 j < Garage.Length;
                                 j++) // Loopar genom efter alla bussar med samma regnummer
                            {
                                if (Garage[j].VehiclesParked.Contains(vehicle))
                                {
                                    Garage[j].VehiclesParked
                                        .Remove(vehicle); // Tar bort bussen från båda platser den stod på.
                                    Garage[j].AvailableCapacity +=
                                        1; // Varje plats bussen stod på får +1, vilket gör den ledig igen.
                                }
                            }
                        }
                        else // Hantering för fordon som inte är buss
                        {
                            Garage[i].VehiclesParked.Remove(vehicle);
                            Garage[i].AvailableCapacity += vehicle.Size;
                        }

                        (double minutesParked, double fee) = Helpers.CalculateParkingFee(vehicle, ParkingFee);
                        // :F2 för att endast skriva ut två decimaler från double variablerna
                        Console.WriteLine(
                            $"{vehicle.Name} med registreringsnummer {vehicle.LicensePlateNumber} har checkat ut. Tid parkerad: {minutesParked:F2} minuter. Avgift: {fee:F2} kr");
                        Thread.Sleep(3000);
                        vehicleFound = true;
                        break; // Avslutar foreach loopen eftersom vi hittade fordonet
                    }
                }
            }
        }

        if (!vehicleFound && !garageEmpty)
        {
            Console.Clear();
            Console.WriteLine("Det finns inget fordon med det angivna registreringsnumret");
            Thread.Sleep(2000);
        }
        else if (garageEmpty)
        {
            Console.Clear();
            Console.WriteLine("Det finns inga bilar att checka ut, garaget är tomt");
            Thread.Sleep(2000);
        }
    }
}