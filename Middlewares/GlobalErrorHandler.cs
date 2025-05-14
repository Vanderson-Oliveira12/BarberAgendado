using Azure.Core;
using BarberAgendado.Domain.Exceptions;
using BarberAgendado.Domain.Models;

namespace BarberAgendado.Middlewares
{
    public class GlobalErrorHandler
    {
        private RequestDelegate _next { get; set; }

        public GlobalErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                context.Response.ContentType = "application/json";

                int statusCode = 500;

                switch (ex)
                {
                    case BusinessLogicException _:
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    default:
                        statusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                context.Response.StatusCode = statusCode;

                var response = ApiResponse.Error(message: ex.Message, statusCode: statusCode);

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
