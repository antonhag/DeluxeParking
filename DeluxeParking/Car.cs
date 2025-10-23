namespace DeluxeParking;

public class Car : Vehicle 
{
    public bool ElectricCar { get; set; }

    public Car(string licensePlateNumber, string vehiclecolor, bool electricCar) : base(licensePlateNumber, vehiclecolor)
    {
        ElectricCar = electricCar;
    }
}

