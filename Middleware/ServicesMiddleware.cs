using FastEndpoints;
using Hycite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Hycite.Repositories;

namespace Hycite.Middleware;

public static class ServicesMiddleware
{
    private static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUserSecurityRepository, UserSecurityRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserActivityRepository, UserActivityRepository>();
    }

    public static void UseServicesMiddleware(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppServices();
        services.AddDbContext<HyciteDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SqlLiteConnection")));

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer"),
                    ValidAudience = configuration["Jwt:Audience"] ?? throw new ArgumentNullException("Jwt:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key")))
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("User", policy => policy.RequireRole("User"));
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
        });

        services.AddFastEndpoints();
    }
}