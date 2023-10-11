namespace InnowiseEntryTask.WebApi.Models;

public class Artist : IModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Biography { get; set; } = null!;

    public ICollection<Album> Albums { get; set; } = null!;
}