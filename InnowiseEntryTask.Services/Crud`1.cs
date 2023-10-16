using InnowiseEntryTask.Data;

namespace InnowiseEntryTask.Services;

public class Crud<TEntity> where TEntity : class, IEntity
{
    public Crud(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly ApplicationDbContext _dbContext;

    public int Create(TEntity entity)
    {
        _dbContext.DbSetOf<TEntity>()
            .Add(entity);
        _dbContext.SaveChanges();
        return entity.Id;
    }

    public TEntity? Read(int id) =>
        _dbContext.DbSetOf<TEntity>()
            .FirstOrDefault(entity => entity.Id == id);

    public IReadOnlyCollection<TEntity> ReadAll() =>
        _dbContext.DbSetOf<TEntity>().ToArray();

    public bool Update(TEntity value)
    {
        var entity = _dbContext.DbSetOf<TEntity>()
            .FirstOrDefault(entity => entity.Id == value.Id);
        
        if (entity is null)
        {
            return false;
        }

        _dbContext.DbSetOf<TEntity>()
            .Update(value);
        _dbContext.SaveChanges();
        
        return true;
    }

    public void Delete(int id)
    {
        var entity = _dbContext.DbSetOf<TEntity>()
            .FirstOrDefault(entity => entity.Id == id);
        
        if (entity is not null)
        {
            _dbContext.DbSetOf<TEntity>()
                .Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}