// transforma clasele C# în tabele reale SQL
using Microsoft.EntityFrameworkCore;
using TourismBackend.Models;

namespace TourismBackend.Data
{
    public class TourismContext : DbContext
    {
        public TourismContext(DbContextOptions<TourismContext> options) : base(options) { }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<DestinationImage> DestinationImages { get; set; }
    }
}