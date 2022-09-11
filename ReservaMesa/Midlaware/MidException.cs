using System.Net;

namespace ReservaMesa.Midlaware
{
    public class MidException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MidException(RequestDelegate next,
            ILogger<MidException> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
                SetStatusCodeDefault(httpContext);
            }
        }

        public void ExceptionHandler(Exception ex)
        {
            _logger.LogInformation(ex.Message);
        }

        public void SetStatusCodeDefault(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 500;
        }
    }
}
