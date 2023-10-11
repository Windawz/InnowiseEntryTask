using InnowiseEntryTask.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi;

[ApiController]
[Route("/Artists")]
public class ArtistController : ModelAwareController<Artist>
{
    public ArtistController(DatabaseContext databaseContext) : base(databaseContext) { }
}