using InnowiseEntryTask.Data;
using InnowiseEntryTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi.Controllers;

[Route("/Songs")]
public class SongController : CrudController<Song>
{
    public SongController(Crud<Song> crud) : base(crud) { }
}