namespace DeluxeParking;

public class Car : Vehicle 
{
    public bool ElectricCar { get; set; }

    public Car(string licensePlateNumber, string vehicleColor, string vehicleName, double vehicleSize, bool electricCar) : base(licensePlateNumber, vehicleColor, vehicleName, vehicleSize)
    {
        ElectricCar = electricCar;
        VehicleName = vehicleName;
    }

    public override string PrintVehicle()
    {
        string vehicleInfo = $"Bil\t{LicensePlateNumber}\t{VehicleColor}\t{(ElectricCar ? "Elbil" : "Ej elbil")}";
        return vehicleInfo;
    }
}

