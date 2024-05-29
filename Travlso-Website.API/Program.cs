using Microsoft.EntityFrameworkCore;
using Travelso_Website.DataAccess;
using Travelso_Website.DataAccess.Repositories;
using Travelso_Website_Shared.Interfaces.IService;
using Travlso_Website.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


var connectionsString = builder.Configuration.GetConnectionString("SQLTravelso");

builder.Services.AddDbContext<TravelsoSQLDataContext>(options =>
{
    options.UseSqlServer(connectionsString);
});


builder.Services.AddScoped<BlogPostRepository>();
builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<DestinationRepository>();
builder.Services.AddScoped<UserRepository>();


var app = builder.Build();

app.CountryEndpoints();
app.DestinationEndpoints();
app.UserEndPoints();
app.BlogPostEndpoints();
app.CommentEndpoints();


app.Run();
