using FastEndpoints;
using Hycite.Data;
using Microsoft.EntityFrameworkCore;

namespace Hycite.Middleware;

public static class ServicesMiddleware
{
    public static void UseServicesMiddleware(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HyciteDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SqlLiteConnection")));

        services.AddFastEndpoints();
    }
}