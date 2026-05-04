

namespace Application.DTOs;

public record CreateKeyPointRequest(
	Guid LessonId,
	string Text
);

