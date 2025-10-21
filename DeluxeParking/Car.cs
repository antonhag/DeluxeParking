namespace DeluxeParking;

public class Car : Vehicle 
{
    public bool ElectricCar { get; set; }

    public Car(int licensePlateNumber, string vehiclecolor, bool electricCar) : base(licensePlateNumber, vehiclecolor)
    {
        ElectricCar = electricCar;
    }
}

