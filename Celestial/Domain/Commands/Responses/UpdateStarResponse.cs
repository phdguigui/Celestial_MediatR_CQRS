using Celestial.API.Domain.ValueObjects;

namespace Celestial.API.Domain.Commands.Responses
{
    public class UpdateStarResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public double Magnitude { get; set; }
        public bool Success { get; set; }

        public UpdateStarResponse(int id, string name, Position position, double magnitude, bool success)
        {
            Id = id;
            Name = name;
            Position = position;
            Magnitude = magnitude;
            Success = success;
        }
    }
}
