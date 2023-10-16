namespace InnowiseEntryTask.Data;

public class Artist : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Biography { get; set; } = null!;

    public ICollection<Album> Albums { get; set; } = null!;
}