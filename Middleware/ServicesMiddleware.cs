using FastEndpoints;
using Hycite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hycite.Middleware;

public static class ServicesMiddleware
{
    public static void UseServicesMiddleware(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HyciteDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SqlLiteConnection")));

        // Check if we are running development environment
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Hycite", Version = "v1" });
            });
        }

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        services.AddFastEndpoints();
    }
}