using InnowiseEntryTask.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi;

[ApiController]
[Route("/Song")]
public class SongController : ModelAwareController<Song>
{
    public SongController(DatabaseContext databaseContext) : base(databaseContext) { }
}