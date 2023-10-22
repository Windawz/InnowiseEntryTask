using InnowiseEntryTask.Data;
using InnowiseEntryTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi.Controllers;

[ApiController]
[Route("/Songs")]
public class SongController : ControllerBase
{
    public SongController(Crud<Song> crud)
    {
        _crud = crud;
    }

    private readonly Crud<Song> _crud;

    [HttpPost]
    public IActionResult Post(Song song)
    {
        _crud.Create(song);
        return CreatedAtAction(nameof(Get), song);
    }

    [HttpGet]
    public IReadOnlyCollection<Song> GetAll() =>
        _crud.ReadAll();

    [HttpGet("{id}")]
    public Song? Get(int id) =>
        _crud.Read(id);

    [HttpPut("{id}")]
    public IActionResult Put(int id, Song song)
    {
        if (song.Id != id)
        {
            song.Id = id;
        }

        if (_crud.Update(song))
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