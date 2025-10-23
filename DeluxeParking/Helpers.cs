namespace DeluxeParking;

public class Helpers
{
    public static string GenerateLicensPlateNumber()
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

    public static List<Vehicle> RandomVehicle(List<Vehicle> vehicles)
    {
        int vehicleRandomizer = Random.Shared.Next(0, 3);

        switch (vehicleRandomizer)
        {
            case 0:
                bool carIsElectric = true;
                
                Console.Write("Skriv in färgen på bilen: ");
                string carColor = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Är bilen en elbil?\n 1. Elbil \n 2. Ej elbil");
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
                vehicles.Add(new Car(GenerateLicensPlateNumber(), carColor, carIsElectric));
                break;
            case 1:
                Console.Write("Skriv in färgen på motorcykeln: ");
                string motorcycleColor = Console.ReadLine();
                Console.Clear();
                Console.Write("Skriv in märket på motorcykeln: ");
                string motorcycleBrand = Console.ReadLine();
                vehicles.Add(new MotorCycle(GenerateLicensPlateNumber(), motorcycleBrand, motorcycleColor));
                break;
            case 2:
                Console.Write("Skriv in färgen på bussen: ");
                string busColor = Console.ReadLine();
                Console.Clear();
                Console.Write("Skriv in antalet platser bussen har: ");
                int numberOfPassengers = int.Parse(Console.ReadLine());
                vehicles.Add(new Bus(GenerateLicensPlateNumber(), busColor, numberOfPassengers));
                break;
        }
        return vehicles;
    }
    
}