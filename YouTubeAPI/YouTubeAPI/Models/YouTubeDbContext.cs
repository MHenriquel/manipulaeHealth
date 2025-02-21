using Microsoft.EntityFrameworkCore;

namespace YouTubeAPI.Models
{
    public class YouTubeDbContext : DbContext
    {
        public YouTubeDbContext(DbContextOptions<YouTubeDbContext> options) : base(options) { }

        public DbSet<Video> Videos { get; set; }
    }
}
