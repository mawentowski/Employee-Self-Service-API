using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EmployeeSelfService.Services.Helpers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);

                // Log it
                _logger.LogWarning(ex.Message);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            var code = ex switch
            {
                ArgumentNullException _ => HttpStatusCode.BadRequest,
                AccessViolationException accessException when accessException.Message.Contains("ABC") => HttpStatusCode.ServiceUnavailable,
                ArgumentOutOfRangeException _ => HttpStatusCode.NotAcceptable,
                ArgumentException _ => HttpStatusCode.BadRequest,
                UnauthorizedAccessException _ => HttpStatusCode.Forbidden,
                NotImplementedException _ => HttpStatusCode.NotFound,
                ConflictException _ => HttpStatusCode.Conflict,
                _ => HttpStatusCode.InternalServerError
            };
            var message = ex.Message;
            if (ex.InnerException != null)
            {
                message += $" {ex.InnerException.Message}";
            }


            var result = JsonConvert.SerializeObject(message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}
