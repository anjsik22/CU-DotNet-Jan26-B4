using FluentValidation;
using System.Net;
using System.Text.Json;
using TicketBookingSystem.TripService.Exceptions;

namespace TicketBookingSystem.TripService.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            int statusCode;
            object response;

            switch (ex)
            {
                // 🔴 Your custom exceptions
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    response = new { message = ex.Message };
                    break;

                case BadRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    response = new { message = ex.Message };
                    break;

                case ValidationException validationEx:
                    statusCode = (int)HttpStatusCode.BadRequest;

                    var errors = validationEx.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => e.ErrorMessage).ToArray()
                        );

                    response = new
                    {
                        message = "Validation failed",
                        errors
                    };
                    break;

                // 🔴 Default
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    response = new { message = "Internal Server Error" };
                    break;
            }

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));

        }
    }
}
