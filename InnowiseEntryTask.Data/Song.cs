namespace InnowiseEntryTask.Data;

public class Song
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int DurationInSeconds { get; set; }

    public Album Album { get; set; } = null!;
}