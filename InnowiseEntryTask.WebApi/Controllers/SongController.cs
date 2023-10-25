using InnowiseEntryTask.Services;
using InnowiseEntryTask.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi.Controllers;

[ApiController]
[Route("/Songs")]
public class SongController : ControllerBase
{
    public SongController(ISongOperator songOperator)
    {
        _songOperator = songOperator;
    }

    private readonly ISongOperator _songOperator;

    [HttpPost]
    public IActionResult Post(SongInputModel song)
    {
        var (id, createdValue) = _songOperator.Add(song);
        return CreatedAtAction(nameof(Get), new { Id = id }, createdValue);
    }

    [HttpGet]
    public IEnumerable<SongOutputModel> GetAll() =>
        _songOperator.GetAll();

    [HttpGet("{id}")]
    public SongOutputModel? Get(int id) =>
        _songOperator.Find(id);

    [HttpPut("{id}")]
    public IActionResult Put(int id, SongInputModel song) => 
        _songOperator.TryFindAndSet(id, song) ? Ok() : NotFound();

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) =>
        _songOperator.TryRemove(id) ? Ok() : NotFound();
}