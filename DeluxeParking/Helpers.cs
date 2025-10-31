namespace DeluxeParking;

public static class Helpers
{
    private static string GenerateLicensPlateNumber()
    {
        string[] licenseLetters =
        {
            "A", "B", "C", "D", "E", "F", "G",
            "H", "I", "J", "K", "L", "M", "N",
            "O", "P", "R", "S", "T", "U",
            "W", "X", "Y", "Z"
        };

        int[] licenseNumbers =
        {
            1, 2, 3, 4, 6, 7, 8, 9
        };

        string licensPlate = "";
        
        for (int i = 0; i < 3; i++)
        {
            licensPlate += licenseLetters[Random.Shared.Next(0, licenseLetters.Length)];
        }

        for (int i = 0; i < 3; i++)
        {
            licensPlate += licenseNumbers[Random.Shared.Next(0, licenseNumbers.Length)];
        }
        
        return licensPlate;
    }

    public static Vehicle RandomVehicle()
    {
        int vehicleRandomizer = Random.Shared.Next(0, 3);

        switch (vehicleRandomizer)
        {
            case 0:
                bool carIsElectric = true;
                
                Console.Write("Skriv in färgen på bilen: ");
                string carColor = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Är bilen en elbil?\n1. Elbil\n2. Ej elbil");
                ConsoleKeyInfo keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.D1:
                        carIsElectric = true;
                        break;
                    case ConsoleKey.D2:
                        carIsElectric = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val!");
                        break;
                }
                return new Car(GenerateLicensPlateNumber(), carColor, "Bil", 1, carIsElectric);
            case 1:
                Console.Write("Skriv in färgen på motorcykeln: ");
                string mcColor = Console.ReadLine();
                Console.Clear();
                Console.Write("Skriv in märket på motorcykeln: ");
                string mcBrand = Console.ReadLine();
                return new MotorCycle(GenerateLicensPlateNumber(), mcColor, "Motorcykel",0.5, mcBrand);
            case 2:
                Console.Write("Skriv in färgen på bussen: ");
                string busColor = Console.ReadLine();
                Console.Clear();
                Console.Write("Skriv in antalet platser bussen har: ");
                int numberOfSeats = int.Parse(Console.ReadLine());
                return new Bus(GenerateLicensPlateNumber(), busColor, "Buss", 2, numberOfSeats);
            default: // Kan egentligen aldrig nås, eftersom Random.Shared.Next endast kan bli 0,1 eller 2. Koden fungerar inte utan denna kodrad, därav finns den.
                return null;
        }
    }
    
    public static void PrintGarage(ParkingSpot[] garage)
    {
        Console.WriteLine("Alla fordon i parkeringshuset just nu:\n");

        int index = 1;
            
        for (int i = 0; i < garage.Length; i++)
        {
            ParkingSpot spot = garage[i];

            if (spot.VehiclesParked.Count > 0)
            {
                foreach (Vehicle vehicle in spot.VehiclesParked)
                {
                    bool busAlreadyPrinted = false;

                    if (i > 0) // i måste vara större än 0, den kan inte jämföra 0 och -1
                    {
                        foreach (Vehicle previousVehicle in garage[i - 1].VehiclesParked)
                        {
                            if (previousVehicle is Bus && previousVehicle.LicensePlateNumber == vehicle.LicensePlateNumber)
                            {
                                busAlreadyPrinted = true;
                                break;
                            }
                        }
                    }
                    if (vehicle is Bus && !busAlreadyPrinted)
                    {
                        Console.WriteLine($"Plats {index}-{index + 1} {vehicle.PrintVehicle()}");
                        index += 2; // +2 för att hoppa över en siffra i utskriften
                    }
                    else if (!(vehicle is Bus))
                    {
                        Console.WriteLine($"Plats {index} {vehicle.PrintVehicle()}");
                        index++;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Plats {index} [Tom]");
                index++;
            }
        }
        Console.WriteLine("\nTryck på valfri knapp för att gå tillbaka...");
        Console.ReadKey();
    }
    
    public static (double minutesParked, double fee) CalculateParkingFee(Vehicle vehicle, double parkingFee)
    {
        TimeSpan parkedDuration = DateTime.Now - vehicle.TimeParked;
        double minutesParked = parkedDuration.TotalMinutes;
        double fee = minutesParked * parkingFee;

        return (Math.Round(minutesParked, 2), Math.Round(fee, 2)); // Math.Round (X, 2) avrundar värdena till två decimaler
    }
    
}