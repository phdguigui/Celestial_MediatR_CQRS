using Celestial.API.Domain.Queries.Responses;
using MediatR;

namespace Celestial.API.Domain.Queries.Requests
{
    public class GetAllStarsQueryRequest : IRequest<List<GetStarResponse>>
    {
        public GetAllStarsQueryRequest()
        {
        }
    }
}
