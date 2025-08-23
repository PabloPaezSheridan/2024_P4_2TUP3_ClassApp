using Application.Interfaces;
using Application.Services;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Injections
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<UserService>();
#endregion


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
