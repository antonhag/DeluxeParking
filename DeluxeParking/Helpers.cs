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
        Vehicle vehicle = null;
        int vehicleRandomizer = Random.Shared.Next(0, 3);
        
        switch (vehicleRandomizer)
        {
            case 0:
                string carColor = ValidateInput("Skriv in färgen på bilen: ", input => //Lambda-uttryck som skickas in som metod till ValidateInput
                    {
                        // Är sann ifall strängens värde inte är null eller endast innehåller mellanslag, och att strängen endast innehåller bokstäver
                        bool success = !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter); 
                        return (success, input);
                    },
                    "Färgen får endast innehålla bokstäver, försök igen" // errorMessage som skickas med in i metoden ValidateInput
                );
                
                bool isCarElectric = false;
                bool validInput = false;

                while (!validInput)
                {
                    Console.Clear();
                    Console.WriteLine("Är bilen en elbil?\n1. Elbil\n2. Ej elbil");
                    ConsoleKeyInfo keyInput = Console.ReadKey(true);
                    switch (keyInput.Key)
                    {
                        case ConsoleKey.D1:
                            isCarElectric = true;
                            validInput = true;
                            break;
                        case ConsoleKey.D2:
                            isCarElectric = false;
                            validInput = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Ogiltigt val! Försök igen");
                            Thread.Sleep(1500);
                            break;
                    }
                }
                vehicle = new Car(GenerateLicensPlateNumber(), carColor, "Bil", 1, isCarElectric);
                break;
            case 1:
                string mcColor = ValidateInput("Skriv in färgen på motorcykeln: ", input =>
                    {
                        bool success = !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter);
                        return (success, input);
                    },
                    "Färgen får endast innehålla bokstäver, försök igen"
                );
                
                Console.Clear();
                Console.Write("Skriv in märket på motorcykeln: ");
                string mcBrand = Console.ReadLine();
                
                vehicle = new MotorCycle(GenerateLicensPlateNumber(), mcColor, "Motorcykel",0.5, mcBrand);
                break;
            case 2:
                string busColor = ValidateInput("Skriv in färgen på bussen: ", input =>
                    {
                        bool success = !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter);
                        return (success, input);
                    },
                    "Färgen får endast innehålla bokstäver, försök igen"
                );

                int numberOfSeats = ValidateInput("Skriv in antalet platser bussen har: ", input =>
                    {
                        bool success = int.TryParse(input, out int value);
                        return (success, value);

                    },
                    "Antalet platser får endast innehålla siffror, försök igen"
                );
              
                vehicle = new Bus(GenerateLicensPlateNumber(), busColor, "Buss", 2, numberOfSeats);
                break;
        }
        return vehicle;
    }
    
    public static (double minutesParked, double fee) CalculateParkingFee(Vehicle vehicle, double parkingFee)
    {
        TimeSpan parkedDuration = DateTime.Now - vehicle.TimeParked;
        double minutesParked = parkedDuration.TotalMinutes;
        double fee = minutesParked * parkingFee;

        if (vehicle is Bus) // Ifall fordonet är en buss blir parkeringsavgiften dubbelt så dyr eftersom bussen tar upp två platser
        {
            fee *= 2;
        }

        return (Math.Round(minutesParked, 2), Math.Round(fee, 2)); // Math.Round (X, 2) avrundar värdena till två decimaler
    }

    // Generisk metod för att läsa och validera användarens inmatning, funkar både för strängar och intar
    // T = datatypen som returneras, i detta fall antingen en int för antal platser eller en sträng för färg 
    // prompt = texten som skrivs ut för användaren, tex "Skriv in färgen på bilen"
    // parser = metod som tolkar input och returnerar en tuple (bool: inmatning giltig?, T: värdet)
    private static T ValidateInput<T>(string prompt, Func<string, (bool, T)> parser, string errorMessage) 
    {
        while (true)
        {
            Console.Clear();            
            Console.Write(prompt);
            string input = Console.ReadLine();
            
            (bool success, T value) = parser(input);
            if (success)
            {
                return value;
            }

            Console.Clear();
            Console.WriteLine(errorMessage);
            Thread.Sleep(1500);
        }
    }
    
}