using Microsoft.EntityFrameworkCore;

namespace InnowiseEntryTask.Data;

[EntityTypeConfiguration(typeof(SongConfiguration))]
public class Song : IEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public TimeSpan Duration { get; set; }

    public Album Album { get; set; } = null!;
}