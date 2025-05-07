using Microsoft.EntityFrameworkCore;
using TouristBookingPlatform.API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tourist Booking API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapMethods("/health", new[] { "HEAD", "GET" }, async (AppDbContext db, HttpContext context) =>
{
    try
    {
        var any = await db.Events.AnyAsync();
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.StatusCode(503);
    }
});


app.Run();
