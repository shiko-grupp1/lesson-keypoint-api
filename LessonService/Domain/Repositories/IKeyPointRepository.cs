using Domain.Entities;

namespace Domain.Repositories;

public interface IKeyPointRepository
{
	Task<List<KeyPoint>> GetByLessonIdAsync(Guid lessonId, CancellationToken ct = default);
	Task AddAsync(KeyPoint keyPoint, CancellationToken ct = default);
}
 