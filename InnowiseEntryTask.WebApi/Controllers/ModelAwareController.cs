using InnowiseEntryTask.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InnowiseEntryTask.WebApi;

[ApiController]
public abstract class ModelAwareController<TModel> : WebApiController where TModel : class, IModel
{
    public ModelAwareController(DatabaseContext databaseContext) : base(databaseContext) { }

    [HttpGet("")]
    public IReadOnlyCollection<TModel> GetAll() =>
        GetDbSet().ToArray();

    [HttpGet("{id}")]
    public ActionResult<TModel> Get(int id) => 
        FindById(id) switch
        {
            null => NotFound(),
            var value => value,
        };

    [HttpPost("")]
    public IActionResult Create(TModel value)
    {
        GetDbSet().Add(value);
        DatabaseContext.SaveChanges();
        return CreatedAtAction(nameof(Get), new { value.Id }, value);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TModel value)
    {
        if (value.Id != id)
        {
            value.Id = id;
        }
        var target = FindById(id);
        if (target is null)
        {
            return NotFound();
        }
        DatabaseContext.Update(value);
        DatabaseContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var target = FindById(id);
        if (target is null)
        {
            return NotFound();
        }
        GetDbSet().Remove(target);
        DatabaseContext.SaveChanges();
        return NoContent();
    }

    private TModel? FindById(int id) =>
        GetDbSet().FirstOrDefault(value => value.Id == id);

    private DbSet<TModel> GetDbSet()
    {
        if (DatabaseContext.Albums is DbSet<TModel> albumSet)
        {
            return albumSet;
        }
        else if (DatabaseContext.Artists is DbSet<TModel> artistSet)
        {
            return artistSet;
        }
        else if (DatabaseContext.Songs is DbSet<TModel> songSet)
        {
            return songSet;
        }
        else
        {
            throw new ArgumentException("DbSet not found for type");
        }
    }
}