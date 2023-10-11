using Microsoft.EntityFrameworkCore;

namespace InnowiseEntryTask.WebApi.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) { }

    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Song> Songs { get; set; } = null!;
}