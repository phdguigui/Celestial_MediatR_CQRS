using Celestial.API.Domain.ValueObjects;

public class Star
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Position Position { get; set; }
    public double Magnitude { get; set; }

    public Star() { }

    public Star(string name, Position position, double magnitude)
    {
        Name = name;
        Position = position;
        Magnitude = magnitude;
    }
}
