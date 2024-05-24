using Microsoft.EntityFrameworkCore;
using Travelso_Website.DataAccess;

var builder = WebApplication.CreateBuilder(args);


var connectionsString = builder.Configuration.GetConnectionString("SQLTravelso");

builder.Services.AddDbContext<TravelsoSQLDataContext>(options =>
{
    options.UseSqlServer(connectionsString);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
