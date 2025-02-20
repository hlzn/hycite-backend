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

        app.UseFastEndpoints();
    }
}