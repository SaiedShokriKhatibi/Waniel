using System.Reflection;
using Waniel.Domains;
using Waniel.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();

//I can use AutoFac in big projects.
builder.Services.AddSingleton<IPlaceService, AirportService>();
builder.Services.AddSingleton<IMapService, GoogleService>();
builder.Services.AddSingleton<IMapService, LocalService>();
builder.Services.AddSingleton<IMapService, DotNetService>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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
