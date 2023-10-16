using InnowiseEntryTask.Data;
using InnowiseEntryTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi.Controllers;

[Route("/Albums")]
public class AlbumController : CrudController<Album>
{
    public AlbumController(Crud<Album> crud) : base(crud) { }
}