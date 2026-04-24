using BookingSystem.Domain.Common;

namespace BookingSystem.API.Common
{
    public class APIErrorResponse
    {
        public bool Success => false;
        public string Code { get; }
        public string Message { get; }
        public int Status { get; }

        public APIErrorResponse(Error error, int status)
        {
            Code = error.ErrorType.GetDescription();
            Message = error.Detail;
            Status = status;
        }
    }
}
