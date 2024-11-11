using Celestial.API.Domain.Commands.Requests;
using Celestial.API.Domain.Commands.Responses;
using Celestial.API.Domain.Data.Interfaces;
using MediatR;

namespace Celestial.API.Domain.Commands.Handlers
{
    public class CreateStarCommandHandler : IRequestHandler<CreateStarCommandRequest, CreateStarResponse>
    {
        private readonly IStarRepository _starRepository;

        public CreateStarCommandHandler(IStarRepository starRepository)
        {
            _starRepository = starRepository;
        }

        public async Task<CreateStarResponse> Handle(CreateStarCommandRequest request, CancellationToken cancellationToken)
        {
            var star = new Star(request.Name, request.Position, request.Magnitude);

            await _starRepository.AddStarAsync(star);

            var response = new CreateStarResponse(star.Id, star.Name, star.Position, star.Magnitude);

            return response;
        }
    }
}
