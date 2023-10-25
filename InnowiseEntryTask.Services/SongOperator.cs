using InnowiseEntryTask.Data;
using InnowiseEntryTask.Services.Models;

namespace InnowiseEntryTask.Services;

public class SongOperator : ISongOperator
{
    public SongOperator(ApplicationDbContext dbContext, IEntityMapper<SongInputModel, Song> entityMapper, IModelMapper<Song, SongOutputModel> modelMapper)
    {
        _dbContext = dbContext;
        _entityMapper = entityMapper;
        _modelMapper = modelMapper;
    }

    private readonly ApplicationDbContext _dbContext;
    private readonly IEntityMapper<SongInputModel, Song> _entityMapper;
    private readonly IModelMapper<Song, SongOutputModel> _modelMapper;

    public (int CreatedId, SongOutputModel CreatedValue) Add(SongInputModel value)
    {
        var entity = _entityMapper.Map(value);
        _dbContext.Songs.Add(entity);
        _dbContext.SaveChanges();
        return (entity.Id, _modelMapper.Map(entity));
    }

    public SongOutputModel? Find(int id)
    {
        Song? entity = _dbContext.Songs.Find(id);
        return entity is not null
            ? _modelMapper.Map(entity)
            : null;
    }

    public IReadOnlyCollection<SongOutputModel> GetAll() =>
        _dbContext.Songs
            .Select(entity => _modelMapper.Map(entity))
            .ToArray();

    public bool TryFindAndSet(int id, SongInputModel value)
    {
        var entity = _dbContext.Songs.Find(id);
        if (entity is not null)
        {
            var newValue = _entityMapper.Map(value);
            newValue.Id = entity.Id;
            _dbContext.Songs.Update(newValue);
            _dbContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryRemove(int id)
    {
        var entity = _dbContext.Songs.Find(id);
        if (entity is not null)
        {
            _dbContext.Songs.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}