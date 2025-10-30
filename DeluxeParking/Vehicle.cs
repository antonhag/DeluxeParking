namespace DeluxeParking;

public abstract class Vehicle // Hade redan skapat basklassen Vehicle innan interface genomgången, därav får den bli abstract istället
{
    public string LicensePlateNumber { get; set; }
    protected string Color { get; set; }
    public string Name { get; set; }
    public double Size { get; set; }
    public DateTime TimeParked { get; set; } = DateTime.Now;

    protected Vehicle(string licensePlateNumber, string color, string name, double size)
    {
        LicensePlateNumber = licensePlateNumber;
        Color = color;
        Name = name;
        Size = size;
    }

    public abstract string PrintVehicle();
}