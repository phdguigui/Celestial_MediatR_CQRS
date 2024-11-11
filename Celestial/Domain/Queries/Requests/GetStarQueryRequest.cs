using Celestial.API.Domain.Queries.Responses;
using MediatR;

namespace Celestial.API.Domain.Queries.Requests
{
    public class GetStarQueryRequest : IRequest<GetStarResponse>
    {
        public int Id { get; set; }

        public GetStarQueryRequest(int id)
        {
            Id = id;
        }
    }
}
