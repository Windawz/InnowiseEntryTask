namespace InnowiseEntryTask.Data;

public class Album
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public ICollection<Song> Songs { get; set; } = null!;
}