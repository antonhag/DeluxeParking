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

    private static int vehicleNumber = 0;
        
    public static Vehicle RandomVehicle()
    {
        Vehicle vehicle = null;
        //int vehicleRandomizer = Random.Shared.Next(0, 3);
        

        switch (vehicleNumber)
        {
            case 0:
            case 4:    
                string carColor = "";
                while (true)
                {
                    Console.Clear();
                    Console.Write("Skriv in färgen på bilen: ");
                    carColor = Console.ReadLine();

                    if (!string.IsNullOrEmpty(carColor) && carColor.All(char.IsLetter))
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Färgen får endast innehålla bokstäver, försök igen");
                    Thread.Sleep(1500);
                }
                
                bool carIsElectric = false;
                bool validInput = false;

                while (!validInput)
                {
                    Console.Clear();
                    Console.WriteLine("Är bilen en elbil?\n1. Elbil\n2. Ej elbil");
                    ConsoleKeyInfo keyInput = Console.ReadKey(true);
                    switch (keyInput.Key)
                    {
                        case ConsoleKey.D1:
                            carIsElectric = true;
                            validInput = true;
                            break;
                        case ConsoleKey.D2:
                            carIsElectric = false;
                            validInput = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Ogiltigt val! Försök igen");
                            Thread.Sleep(1500);
                            break;
                    }
                }
                vehicle = new Car(GenerateLicensPlateNumber(), carColor, "Bil", 1, carIsElectric);
                break;
            case 1:
            case 2:    
                string mcColor = "";
                while (true)
                {
                    Console.Clear();
                    Console.Write("Skriv in färgen på motorcykeln: ");
                    mcColor = Console.ReadLine();

                    if (!string.IsNullOrEmpty(mcColor) && mcColor.All(char.IsLetter))
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Färgen får endast innehålla bokstäver, försök igen");
                    Thread.Sleep(1500);
                }
                
                Console.Clear();
                Console.Write("Skriv in märket på motorcykeln: ");
                string mcBrand = Console.ReadLine();
                
                vehicle = new MotorCycle(GenerateLicensPlateNumber(), mcColor, "Motorcykel",0.5, mcBrand);
                break;
            case 3:
            case 5:
                string busColor = "";
                while (true)
                {
                    Console.Write("Skriv in färgen på bussen: ");
                    busColor = Console.ReadLine();

                    if (!string.IsNullOrEmpty(busColor) && busColor.All(char.IsLetter))
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Färgen får endast innehålla bokstäver, försök igen");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
                Console.Clear();

                int numberOfSeats = 0;
                while (true)
                {
                    Console.Clear();
                    Console.Write("Skriv in antalet platser bussen har: ");
                    string input = Console.ReadLine();

                    try
                    {
                        numberOfSeats = int.Parse(input);
                        break;
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Antalet platser får endast innehålla siffror, försök igen");
                        Thread.Sleep(1500);
                    }
                }
                vehicle = new Bus(GenerateLicensPlateNumber(), busColor, "Buss", 2, numberOfSeats);
                break;
        }
        vehicleNumber++;
        return vehicle;
    }
    
    public static (double minutesParked, double fee) CalculateParkingFee(Vehicle vehicle, double parkingFee)
    {
        TimeSpan parkedDuration = DateTime.Now - vehicle.TimeParked;
        double minutesParked = parkedDuration.TotalMinutes;
        double fee = minutesParked * parkingFee;

        if (vehicle is Bus)
        {
            fee *= 2;
        }

        return (Math.Round(minutesParked, 2), Math.Round(fee, 2)); // Math.Round (X, 2) avrundar värdena till två decimaler
    }
    
}