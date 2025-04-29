using Microsoft.EntityFrameworkCore;
using TouristBookingPlatform.API.Models;

namespace TouristBookingPlatform.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
