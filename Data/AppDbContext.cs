using Microsoft.EntityFrameworkCore;
using challenge_total.Data.Entities;

namespace challenge_total.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Button> Buttons { get; set; }
    }
}
