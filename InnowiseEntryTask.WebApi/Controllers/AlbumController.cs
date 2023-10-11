using InnowiseEntryTask.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi;

[ApiController]
[Route("/Albums")]
public class AlbumController : ModelAwareController<Album>
{
    public AlbumController(DatabaseContext databaseContext) : base(databaseContext) { }
}