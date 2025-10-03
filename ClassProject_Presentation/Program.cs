using Application.Interfaces;
using Application.Services;
using Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Infrastructure.ExternalServices;
using Infrastructure.Repositories;
using Infrastructure.ExternalServices.PokeApi;


var builder = WebApplication.CreateBuilder(args);

#region External Services

PollySettings pokeApiResilienceConfiguration = new()
{
    RetryCount = 2,
    RetryAttemptInSeconds = 3,
    DurationOfBreakInSeconds = 120,
    HandledEventsAllowedBeforeBreaking = 10
};

builder.Services.AddHttpClient(
    "pokeHttpClient",
    client =>
    {
        client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
    })
    .AddPolicyHandler(ResiliencePolicies.GetRetryPolicy(pokeApiResilienceConfiguration))
    .AddPolicyHandler(ResiliencePolicies.GetCircuitBreakerPolicy(pokeApiResilienceConfiguration));

#endregion

#region Injections
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddSingleton<BerryService>();
#endregion

string connectionString = builder.Configuration["ConnectionStrings:ConsultaAlumnosDBConnectionString"]!;

// Configure the SQLite connection
var connection = new SqliteConnection(connectionString);
connection.Open();
builder.Services.AddDbContext<TUP3Context>(dbContextOptions => dbContextOptions.UseSqlite(connection));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
