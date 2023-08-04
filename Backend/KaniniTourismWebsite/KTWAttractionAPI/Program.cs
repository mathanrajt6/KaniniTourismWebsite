using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using KTWAttractionAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
////
builder.Services.AddDbContext<db_LocationsContext>(
      options => options.UseSqlServer(builder.Configuration.GetConnectionString("myConn"))
    );
builder.Services.AddScoped<IRepo<Attraction, int>, AttractionRepo>();
builder.Services.AddScoped<IBaseRepo<AttractionLikes, int>, AttractionLikesRepo>();
builder.Services.AddScoped<IUserAction, UserService>();
builder.Services.AddScoped<ICommonRepo<State,int>, StateRepo>();
builder.Services.AddScoped<ICommonRepo<Country, int>, CountryRepo>();
builder.Services.AddScoped<ICommonRepo<City, int>, CityRepo>();
builder.Services.AddScoped<ILocationAction, LocationService>();


////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
