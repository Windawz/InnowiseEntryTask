using InnowiseEntryTask.Data;

namespace InnowiseEntryTask.Services;

public class Crud<TEntity> where TEntity : class, IEntity
{
    public Crud(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly ApplicationDbContext _dbContext;

    public void Create(TEntity entity)
    {
        _dbContext.DbSetOf<TEntity>()
            .Add(entity);
        _dbContext.SaveChanges();
    }

    public TEntity? Read(int id) =>
        _dbContext.DbSetOf<TEntity>()
            .FirstOrDefault(entity => entity.Id == id);

    public void Update(TEntity value)
    {
        _dbContext.DbSetOf<TEntity>()
            .Update(value);
        _dbContext.SaveChanges();
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