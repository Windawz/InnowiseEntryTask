namespace InnowiseEntryTask.WebApi.Models;

public class Song : IModel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int DurationInSeconds { get; set; }

    public Album? Album { get; set; }
}