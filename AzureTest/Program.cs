using AzureTest.Extensions;
using AzureTest.Interfaces;
using AzureTest.Services;
using AzureTest.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddHealthChecks();

var connectionString = Environment.GetEnvironmentVariable("dbConnectionString");

Console.WriteLine("Test");
Console.WriteLine(connectionString);

builder.Services.AddDbContext<Context>(options => 
    options.UseNpgsql(connectionString)
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureDependencyInjection(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();

void ConfigureDependencyInjection(IServiceCollection services)
{
    services.AddScoped<IUsersService, UsersService>();
    services.AddScoped<IAuthService, AuthService>();
}