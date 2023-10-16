using InnowiseEntryTask.Data;
using InnowiseEntryTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi.Controllers;

[ApiController]
public abstract class CrudController<TEntity> : ControllerBase where TEntity: class, IEntity
{
    protected CrudController(Crud<TEntity> crud)
    {
        _crud = crud;
    }

    private readonly Crud<TEntity> _crud;

    [HttpPost]
    public IActionResult Post(TEntity entity)
    {
        _crud.Create(entity);
        return CreatedAtAction(nameof(Get), entity);
    }

    [HttpGet]
    public IReadOnlyCollection<TEntity> GetAll() =>
        _crud.ReadAll();

    [HttpGet("{id}")]
    public TEntity? Get(int id) =>
        _crud.Read(id);

    [HttpPut("{id}")]
    public IActionResult Put(int id, TEntity value)
    {
        if (value.Id != id)
        {
            value.Id = id;
        }

        if (_crud.Update(value))
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_crud.Delete(id))
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}