using Celestial.API.Domain.ValueObjects;

namespace Celestial.API.Domain.Queries.Responses
{
    public class GetStarResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public double Magnitude { get; set; }

        public GetStarResponse(int id, string name, Position position, double magnitude)
        {
            Id = id;
            Name = name;
            Position = position;
            Magnitude = magnitude;
        }
    }
}
