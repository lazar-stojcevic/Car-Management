namespace CarManagement.Domain;

public class Car : Entity
{
    // Setters should be private, but in lack of time, I will leave them public
    public string Manufacturer { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public uint Year { get; set; }
    public string Color { get; set; } = string.Empty;
    public bool IsElectric { get; set; }
}
