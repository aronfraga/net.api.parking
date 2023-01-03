using Microsoft.EntityFrameworkCore;
using ParkingApp.Data;
using ParkingApp.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Context>(conection => conection.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISpotRepository, SpotRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<Context>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
