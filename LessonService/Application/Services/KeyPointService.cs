using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class LessonService
{
	private readonly IKeyPointRepository _repository;

	public LessonService(IKeyPointRepository repository)
	{
		_repository = repository;
	}

	public async Task<List<string>> GetKeyPointsAsync(Guid lessonId)
	{
		var keyPoints = await _repository.GetByLessonIdAsync(lessonId);

		return keyPoints.Select(x => x.Text).ToList();
	}

	public async Task CreateAsync(Guid lessonId, string text)
	{
		var keyPoint = new KeyPoint(lessonId, text);

		await _repository.AddAsync(keyPoint);
	}
}