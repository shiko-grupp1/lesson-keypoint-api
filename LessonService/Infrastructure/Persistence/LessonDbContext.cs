namespace Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Domain.Entities;

public class LessonDbContext : DbContext
{
	public LessonDbContext(DbContextOptions<LessonDbContext> options)
		: base(options) { }

	public DbSet<KeyPoint> KeyPoints => Set<KeyPoint>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<KeyPoint>(builder =>
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Text)
				   .IsRequired();

			builder.Property(x => x.LessonId)
				   .IsRequired();
		});
	}
}