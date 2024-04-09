using Microsoft.EntityFrameworkCore;
using CoffeeTrackerApi.Models;

namespace CoffeeTrackerApi.Data
{
    public class CoffeeTrackerApiContext : DbContext
    {
        public CoffeeTrackerApiContext (DbContextOptions<CoffeeTrackerApiContext> options)
            : base(options)
        {
        }

        public DbSet<Records> Records { get; set; } = default!;
    }
}
