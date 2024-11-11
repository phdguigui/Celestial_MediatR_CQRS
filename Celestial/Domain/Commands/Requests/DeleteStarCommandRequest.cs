using MediatR;
using Celestial.API.Domain.Commands.Responses;

namespace Celestial.API.Domain.Commands.Requests
{
    public class DeleteStarCommandRequest : IRequest<DeleteStarResponse>
    {
        public int Id { get; set; }

        public DeleteStarCommandRequest(int id)
        {
            Id = id;
        }
    }
}
