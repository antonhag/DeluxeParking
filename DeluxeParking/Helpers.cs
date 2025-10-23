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
    
}