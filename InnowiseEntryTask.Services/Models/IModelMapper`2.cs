namespace InnowiseEntryTask.Services.Models;

public interface IModelMapper<TEntity, TModel> where TEntity : class
{
    TModel Map(TEntity entity);
}