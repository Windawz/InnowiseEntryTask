using Microsoft.EntityFrameworkCore;
using InnowiseEntryTask.Data;
using System.Reflection;

namespace InnowiseEntryTask.Services;

internal static class ApplicationDbContextExtensions
{
    private static readonly IReadOnlyDictionary<Type, Func<ApplicationDbContext, object>> _dbSetGettersPerType =
        new Dictionary<Type, Func<ApplicationDbContext, object>>
        {
            { typeof(Album), context => context.Albums },
            { typeof(Artist), context => context.Artists },
            { typeof(Song), context => context.Songs },
        };

    public static DbSet<TEntity> DbSetOf<TEntity>(this ApplicationDbContext context) where TEntity : class, IEntity
    {
        var entityType = typeof(TEntity);
        if (_dbSetGettersPerType.TryGetValue(entityType, out var getter))
        {
            return (DbSet<TEntity>)getter(context);
        }
        else
        {
            return FindDbSetAmongProperties<TEntity>(context)
                ?? throw new ArgumentException(
                    message: $"ApplicationDbContext does not have a DbSet of type {typeof(TEntity)}",
                    paramName: nameof(context)
                );
        }
    }

    private static DbSet<TEntity>? FindDbSetAmongProperties<TEntity>(ApplicationDbContext context) where TEntity : class, IEntity
    {
        PropertyInfo? propertyInfo = context.GetType()
            .GetProperties()
            .FirstOrDefault(propertyInfo => propertyInfo.PropertyType == typeof(DbSet<TEntity>));
        
        if (propertyInfo is null)
        {
            return null;
        }

        object? rawValue = propertyInfo.GetValue(context);

        if (rawValue is null or not DbSet<TEntity>)
        {
            throw new InvalidOperationException("Got invalid value when getting DbSet from ApplicationDbContext through reflection");
        }

        return (DbSet<TEntity>)rawValue;
    }
}