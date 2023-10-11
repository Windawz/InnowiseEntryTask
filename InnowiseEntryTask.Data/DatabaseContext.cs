using Microsoft.EntityFrameworkCore;

namespace InnowiseEntryTask.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Song> Songs { get; set; } = null!;
}