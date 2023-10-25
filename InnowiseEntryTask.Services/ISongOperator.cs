using InnowiseEntryTask.Services.Models;

namespace InnowiseEntryTask.Services;

public interface ISongOperator
{
    (int CreatedId, SongOutputModel CreatedValue) Add(SongInputModel value);
    IReadOnlyCollection<SongOutputModel> GetAll();
    SongOutputModel? Find(int id);
    bool TryFindAndSet(int id, SongInputModel value);
    bool TryRemove(int id);
}