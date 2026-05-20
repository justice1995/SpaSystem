using Auth.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Common
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
                return new OkObjectResult(new APISuccessReponse<T>(result.Value));

            return result.Error.ErrorType switch
            {
                ErrorType.Notfound => new NotFoundObjectResult(new APIErrorResponse(result.Error, StatusCodes.Status404NotFound)),
                ErrorType.BadRequest => new BadRequestObjectResult(new APIErrorResponse(result.Error, StatusCodes.Status400BadRequest)),
                _ => new BadRequestObjectResult(new APIErrorResponse(result.Error, StatusCodes.Status400BadRequest))
            };

        }
    }
}
