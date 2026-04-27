using System.Diagnostics;

namespace BookingSystem.API.Middlewares
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;
        public RequestTimingMiddleware(RequestDelegate _next, ILogger<RequestTimingMiddleware> _logger)
        {
            this._next = _next;
            this._logger = _logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();

                var method = context.Request.Method;
                var path = context.Request.Path;
                var statusCode = context.Response.StatusCode;
                var elapsedMs = stopwatch.ElapsedMilliseconds;

                _logger.LogInformation(
                "HTTP {Method} {Path} => {StatusCode} in {ElapsedMs} ms",
                method,
                path,
                statusCode,
                elapsedMs);

            }
        }


    }
}
