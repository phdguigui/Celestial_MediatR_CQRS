namespace Celestial.API.Domain.Commands.Responses
{
    public class DeleteStarResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public DeleteStarResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
