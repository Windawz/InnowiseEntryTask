using InnowiseEntryTask.Data;
using InnowiseEntryTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi.Controllers;

[ApiController]
[Route("/Albums")]
public class AlbumController : ControllerBase
{
    public AlbumController(Crud<Album> crud)
    {
        _crud = crud;
    }

    private readonly Crud<Album> _crud;

    [HttpPost]
    public IActionResult Post(Album album)
    {
        _crud.Create(album);
        return CreatedAtAction(nameof(Get), album);
    }

    [HttpGet]
    public IReadOnlyCollection<Album> GetAll() =>
        _crud.ReadAll();

    [HttpGet("{id}")]
    public Album? Get(int id) =>
        _crud.Read(id);

    [HttpPut("{id}")]
    public IActionResult Put(int id, Album album)
    {
        if (album.Id != id)
        {
            album.Id = id;
        }

        if (_crud.Update(album))
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