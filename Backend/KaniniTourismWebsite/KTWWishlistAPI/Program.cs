using KTWWishlistAPI.Interfaces;
using KTWWishlistAPI.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
///
builder.Services.AddScoped<SqlConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("myConn")));
builder.Services.AddScoped<IRepo, WishListRepo>();
builder.Services.AddScoped<IUserAction, UserService>();

///

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
