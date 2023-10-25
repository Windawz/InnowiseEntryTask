using System.ComponentModel.DataAnnotations;

namespace InnowiseEntryTask.Services.Models;

public record SongOutputModel(
    int Id,
    string Title,
    [property: DisplayFormat(DataFormatString = SongModels.DurationDisplayFormat)]
    TimeSpan Duration,
    int AlbumId
);