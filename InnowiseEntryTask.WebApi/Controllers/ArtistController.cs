using InnowiseEntryTask.Data;
using InnowiseEntryTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi.Controllers;

[ApiController]
[Route("/Artists")]
public class ArtistController : ControllerBase
{
    public ArtistController(Crud<Artist> crud)
    {
        _crud = crud;
    }

    private readonly Crud<Artist> _crud;

    [HttpPost]
    public IActionResult Post(Artist artist)
    {
        _crud.Create(artist);
        return CreatedAtAction(nameof(Get), artist);
    }

    [HttpGet]
    public IReadOnlyCollection<Artist> GetAll() =>
        _crud.ReadAll();

    [HttpGet("{id}")]
    public Artist? Get(int id) =>
        _crud.Read(id);

    [HttpPut("{id}")]
    public IActionResult Put(int id, Artist artist)
    {
        if (artist.Id != id)
        {
            artist.Id = id;
        }

        if (_crud.Update(artist))
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