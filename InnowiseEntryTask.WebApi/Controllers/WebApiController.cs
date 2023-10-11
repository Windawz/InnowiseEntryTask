using InnowiseEntryTask.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnowiseEntryTask.WebApi;

[ApiController]
public abstract class WebApiController : ControllerBase
{
    protected WebApiController(DatabaseContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    protected DatabaseContext DatabaseContext { get; }
}