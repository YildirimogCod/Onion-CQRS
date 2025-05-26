using Microsoft.AspNetCore.Builder;

namespace Application.Exceptions
{
    public static class ConfigureExceptionMiddleware
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
