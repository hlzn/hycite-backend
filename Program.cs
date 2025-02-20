using Hycite.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseServicesMiddleware(builder.Configuration);

var app = builder.Build();

app.UseAppMiddleware();

app.Run();
