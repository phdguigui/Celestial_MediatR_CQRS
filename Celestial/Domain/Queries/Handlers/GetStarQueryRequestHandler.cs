using Celestial.API.Domain.Data.Interfaces;
using Celestial.API.Domain.Queries.Requests;
using Celestial.API.Domain.Queries.Responses;
using MediatR;

namespace Celestial.API.Domain.Queries.Handlers
{
    public class GetStarQueryRequestHandler : IRequestHandler<GetStarQueryRequest, GetStarResponse>
    {
        private readonly IStarRepository _starRepository;

        public GetStarQueryRequestHandler(IStarRepository starRepository)
        {
            _starRepository = starRepository;
        }

        public async Task<GetStarResponse> Handle(GetStarQueryRequest request, CancellationToken cancellationToken)
        {
            var star = await _starRepository.GetStarByIdAsync(request.Id);

            if (star == null)
            {
                return null;
            }

            return new GetStarResponse(
                star.Id,
                star.Name,
                star.Position,
                star.Magnitude
            );
        }
    }
}
