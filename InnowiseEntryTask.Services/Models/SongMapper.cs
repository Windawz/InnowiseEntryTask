using InnowiseEntryTask.Data;

namespace InnowiseEntryTask.Services.Models;

public class SongMapper : IEntityMapper<SongInputModel, Song>, IModelMapper<Song, SongOutputModel>
{
    public SongMapper(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly ApplicationDbContext _dbContext;

    public Song Map(SongInputModel model)
    {
        var album = _dbContext.Albums.Find(model.AlbumId)
            ?? throw new MappingException(message: "Album of provided song with provided album id not found");

        return new()
        {
            Id = default,
            Title = model.Title,
            Duration = model.Duration,
            Album = album
        };
    }

    public SongOutputModel Map(Song entity)
    {
        return new(
            Id: entity.Id,
            Title: entity.Title,
            Duration: entity.Duration,
            AlbumId: entity.Album.Id
        );
    }
}