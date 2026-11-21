namespace Yadino.Application.Features.Notes.CreateNote;

public sealed record CreateNoteCommand(string Title, string Content);

public sealed record CreateNoteResult(
    Guid Id,
    string Title,
    string Content,
    DateTime CreatedAtUtc,
    DateTime UpdatedAtUtc);