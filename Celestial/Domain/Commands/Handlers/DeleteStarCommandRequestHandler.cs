using Celestial.API.Domain.Commands.Requests;
using Celestial.API.Domain.Commands.Responses;
using Celestial.API.Domain.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Celestial.API.Domain.Commands.Handlers
{
    public class DeleteStarCommandHandler : IRequestHandler<DeleteStarCommandRequest, DeleteStarResponse>
    {
        private readonly IStarRepository _starRepository;

        public DeleteStarCommandHandler(IStarRepository starRepository)
        {
            _starRepository = starRepository;
        }

        public async Task<DeleteStarResponse> Handle(DeleteStarCommandRequest request, CancellationToken cancellationToken)
        {
            var star = await _starRepository.GetStarByIdAsync(request.Id);

            if (star == null)
            {
                return new DeleteStarResponse(false, "Star not found.");
            }

            await _starRepository.DeleteStarAsync(star.Id);

            return new DeleteStarResponse(true, "Star deleted successfully.");
        }
    }
}
