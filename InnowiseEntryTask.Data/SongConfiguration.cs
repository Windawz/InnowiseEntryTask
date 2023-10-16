using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnowiseEntryTask.Data;

internal class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.Property(song => song.Duration)
            .HasConversion(
                duration => duration.Seconds,
                seconds => TimeSpan.FromSeconds(seconds)
            );
    }
}