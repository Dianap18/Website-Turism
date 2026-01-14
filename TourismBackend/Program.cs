using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TourismBackend.Data;
using TourismBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TourismContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000", "http://localhost:5173") 
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TourismContext>();
        
        context.Database.EnsureCreated();

        DbSeeder.Seed(context);
        
        BookingManager.Instance.LoadFromDatabase(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "A apărut o eroare la popularea bazei de date.");
    }
}

app.Run();