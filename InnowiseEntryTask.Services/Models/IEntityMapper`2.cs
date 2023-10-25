namespace InnowiseEntryTask.Services.Models;

public interface IEntityMapper<TModel, TEntity> where TEntity : class
{
    TEntity Map(TModel model);
}