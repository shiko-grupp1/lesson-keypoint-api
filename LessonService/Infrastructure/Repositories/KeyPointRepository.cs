namespace Infrastructure.Repositories;

using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

public class KeyPointRepository : IKeyPointRepository
{
	private readonly LessonDbContext _context;

	public KeyPointRepository(LessonDbContext context)
	{
		_context = context;
	}

	public async Task<List<KeyPoint>> GetByLessonIdAsync(Guid lessonId, CancellationToken ct = default)
	{
		return await _context.KeyPoints
			.Where(x => x.LessonId == lessonId)
			.ToListAsync(ct);
	}

	public async Task AddAsync(KeyPoint keyPoint, CancellationToken ct = default)
	{
		await _context.KeyPoints.AddAsync(keyPoint, ct);
		await _context.SaveChangesAsync(ct);
	}
}