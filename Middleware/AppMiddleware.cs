using FastEndpoints;

namespace Hycite.Middleware;

public static class AppMiddleware
{
    public static void UseAppMiddleware(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/test", () => "200");
        });

        // Check if we are running development environment
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hycite v1"));
        }

        app.UseFastEndpoints();
    }
}