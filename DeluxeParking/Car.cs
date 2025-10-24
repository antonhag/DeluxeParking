namespace DeluxeParking;

public class Car : Vehicle 
{
    public bool ElectricCar { get; set; }

    public Car(string licensePlateNumber, string vehiclecolor, double vehicleSize, bool electricCar) : base(licensePlateNumber, vehiclecolor, vehicleSize)
    {
        ElectricCar = electricCar;
    }

    public override string PrintVehicle()
    {
        string vehicleInfo = $"Bil\t{LicensePlateNumber}\t{VehicleColor}\t{(ElectricCar ? "Elbil" : "Ej elbil")}";
        return vehicleInfo;
    }
}

