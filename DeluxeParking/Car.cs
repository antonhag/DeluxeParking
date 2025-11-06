namespace DeluxeParking;

public class Car : Vehicle 
{
    private bool IsCarElectric { get; set; }

    public Car(string licensePlateNumber, string color, string name, double size, bool isCarElectric) : base(licensePlateNumber, color, name, size)
    {
        IsCarElectric = isCarElectric;
    }

    public override string PrintVehicle()
    {
        string vehicleInfo = $"\tBil\t{LicensePlateNumber}\t{Color}\t{(IsCarElectric ? "Elbil" : "Ej elbil")}"; // En ternary operator som skriver ut "Elbil" ifall villkoret är sant, annars "Ej elbil"
        return vehicleInfo;
    }
}

