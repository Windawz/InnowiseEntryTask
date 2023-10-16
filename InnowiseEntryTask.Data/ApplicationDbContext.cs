using Microsoft.EntityFrameworkCore;

namespace InnowiseEntryTask.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Artist> Artists { get; set; } = null!;
    
    public DbSet<Album> Albums { get; set; } = null!;

    public DbSet<Song> Songs { get; set; } = null!;
}