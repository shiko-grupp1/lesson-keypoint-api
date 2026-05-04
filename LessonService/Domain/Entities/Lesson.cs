namespace Domain.Entities;

public class KeyPoint
{
	public Guid Id { get; private set; }
	public Guid LessonId { get; private set; }
	public string Text { get; private set; } = null!;

	private KeyPoint() { }

	public KeyPoint(Guid lessonId, string text)
	{
		Id = Guid.NewGuid();
		LessonId = lessonId;
		Text = text;
	}
}