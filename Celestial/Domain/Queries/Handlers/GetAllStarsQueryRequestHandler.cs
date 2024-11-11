using Celestial.API.Domain.Data.Interfaces;
using Celestial.API.Domain.Queries.Requests;
using Celestial.API.Domain.Queries.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Celestial.API.Domain.Queries.Handlers
{
    public class GetAllStarsQueryRequestHandler : IRequestHandler<GetAllStarsQueryRequest, List<GetStarResponse>>
    {
        private readonly IStarRepository _starRepository;

        public GetAllStarsQueryRequestHandler(IStarRepository starRepository)
        {
            _starRepository = starRepository;
        }

        public async Task<List<GetStarResponse>> Handle(GetAllStarsQueryRequest request, CancellationToken cancellationToken)
        {
            var stars = await _starRepository.GetAllStarsAsync();

            var starResponses = new List<GetStarResponse>();

            foreach (var star in stars)
            {
                var starResponse = new GetStarResponse(
                    star.Id,
                    star.Name,
                    star.Position,
                    star.Magnitude
                );
                starResponses.Add(starResponse);
            }

            return starResponses;
        }
    }
}
