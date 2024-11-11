using Celestial.API.Domain.Commands.Requests;
using Celestial.API.Domain.Commands.Responses;
using Celestial.API.Domain.Data.Interfaces;
using MediatR;

namespace Celestial.API.Domain.Commands.Handlers
{
    public class UpdateStarCommandHandler : IRequestHandler<UpdateStarCommandRequest, UpdateStarResponse>
    {
        private readonly IStarRepository _starRepository;

        public UpdateStarCommandHandler(IStarRepository starRepository)
        {
            _starRepository = starRepository;
        }

        public async Task<UpdateStarResponse> Handle(UpdateStarCommandRequest request, CancellationToken cancellationToken)
        {
            var star = await _starRepository.GetStarByIdAsync(request.Id);

            if (star == null)
            {
                throw new KeyNotFoundException("Star not found.");
            }

            star.Name = request.Name;
            star.Position = request.Position;
            star.Magnitude = request.Magnitude;

            await _starRepository.UpdateStarAsync(star);

            var response = new UpdateStarResponse(star.Id, star.Name, star.Position, star.Magnitude, true);

            return response;
        }
    }
}
