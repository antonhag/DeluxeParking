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

        string licensplate = "";
        
        for (int i = 0; i < 3; i++)
        {
            licensplate += licenseLetters[Random.Shared.Next(0, licenseLetters.Length)];
        }

        for (int i = 0; i < 3; i++)
        {
            licensplate += licenseNumbers[Random.Shared.Next(0, licenseNumbers.Length)];
        }
        
        return licensplate;
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
    
}