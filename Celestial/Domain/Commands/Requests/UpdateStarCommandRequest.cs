using Celestial.API.Domain.Commands.Responses;
using Celestial.API.Domain.ValueObjects;
using MediatR;

namespace Celestial.API.Domain.Commands.Requests
{
    public class UpdateStarCommandRequest : IRequest<UpdateStarResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public double Magnitude { get; set; }

        public UpdateStarCommandRequest(int id, string name, Position position, double magnitude)
        {
            Id = id;
            Name = name;
            Position = position;
            Magnitude = magnitude;
        }
    }
}
