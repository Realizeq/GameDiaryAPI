using Microsoft.EntityFrameworkCore;
using GameDiary.API.Models;

namespace GameDiary.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}