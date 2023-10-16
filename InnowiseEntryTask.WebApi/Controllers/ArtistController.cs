using InnowiseEntryTask.Data;
using InnowiseEntryTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi.Controllers;

[Route("/Artists")]
public class ArtistController : CrudController<Artist>
{
    public ArtistController(Crud<Artist> crud) : base(crud) { }
}