using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace Application.Exceptions
{
    public class ExceptionMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        public static Task HandleException(HttpContext context, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((ValidationException)exception).Errors.Select(e => e.ErrorMessage).ToList(),
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());
            }

            List<string> errors = new()
            {
                exception.Message
            };
            return context.Response.WriteAsync(new ExceptionModel
            {
                StatusCode = statusCode,
                Errors = errors
            }.ToString());
        }
        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                ArgumentException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };
        }
}
