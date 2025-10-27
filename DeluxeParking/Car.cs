namespace DeluxeParking;

public class Car : Vehicle 
{
    private bool ElectricCar { get; set; }

    public Car(string licensePlateNumber, string color, string name, double size, bool electricCar) : base(licensePlateNumber, color, name, size)
    {
        ElectricCar = electricCar;
    }

    public override string PrintVehicle()
    {
        string vehicleInfo = $"\tBil\t{LicensePlateNumber}\t{Color}\t{(ElectricCar ? "Elbil" : "Ej elbil")}";
        return vehicleInfo;
    }
}

