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
        _dbContext.Set<TEntity>()
            .Add(entity);
        _dbContext.SaveChanges();
        return entity.Id;
    }

    public TEntity? Read(int id) =>
        _dbContext.Set<TEntity>()
            .FirstOrDefault(entity => entity.Id == id);

    public IReadOnlyCollection<TEntity> ReadAll() =>
        _dbContext.Set<TEntity>().ToArray();

    public bool Update(TEntity value)
    {
        var entity = _dbContext.Set<TEntity>()
            .FirstOrDefault(entity => entity.Id == value.Id);
        
        if (entity is null)
        {
            return false;
        }

        _dbContext.Set<TEntity>()
            .Update(value);
        _dbContext.SaveChanges();
        
        return true;
    }

    public bool Delete(int id)
    {
        var entity = _dbContext.Set<TEntity>()
            .FirstOrDefault(entity => entity.Id == id);
        
        if (entity is not null)
        {
            _dbContext.Set<TEntity>()
                .Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}