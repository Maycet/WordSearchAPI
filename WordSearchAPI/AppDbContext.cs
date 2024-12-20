using Microsoft.EntityFrameworkCore;
using WordSearchAPI.Models;

namespace WordSearchAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WordSearchLog> WordSearchLogs { get; set; }
    }
}
