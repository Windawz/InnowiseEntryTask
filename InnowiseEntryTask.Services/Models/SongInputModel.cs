using System.ComponentModel.DataAnnotations;

namespace InnowiseEntryTask.Services.Models;

public record SongInputModel(
    string Title,
    [property: DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = SongModels.DurationDisplayFormat)]
    TimeSpan Duration,
    int AlbumId
);