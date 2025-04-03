namespace CarManagement.Domain;

public class Car : Entity
{
    public string Manufacturer { get; private set; } = string.Empty;
    public string ModelName { get; private set; } = string.Empty;
    public uint Year { get; private set; }
    public string Color { get; private set; } = string.Empty;
    public bool IsElectric { get; private set; }
}
