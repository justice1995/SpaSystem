

using Auth.Application.Common;

namespace Auth.Api.Common
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
