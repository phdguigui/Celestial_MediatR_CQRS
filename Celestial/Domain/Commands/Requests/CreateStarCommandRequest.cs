using MediatR;
using Celestial.API.Domain.Commands.Responses;
using Celestial.API.Domain.ValueObjects;

namespace Celestial.API.Domain.Commands.Requests
{
    public class CreateStarCommandRequest : IRequest<CreateStarResponse>
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public double Magnitude { get; set; }

        public CreateStarCommandRequest(string name, Position position, double magnitude)
        {
            Name = name;
            Position = position;
            Magnitude = magnitude;
        }
    }
}
