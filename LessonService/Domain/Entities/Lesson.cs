namespace Domain.Entities;

public class Lesson
{
	public Guid Id { get; set; }
	public string Title { get; private set; }

	private readonly List<string> _keyPoints = new();
	public IReadOnlyCollection<string> KeyPoints => _keyPoints;

	private Lesson() { } 

	public Lesson(string title)
	{
		Id = Guid.NewGuid();
		Title = title;
	}

	public void AddKeyPoint(string keyPoint)
	{
		_keyPoints.Add(keyPoint);
	}
}
