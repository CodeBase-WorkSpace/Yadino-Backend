namespace Yadino.Api.Features.Notes.CreateNote;

public sealed record CreateNoteResponse(
    Guid Id,
    string Title,
    string Content,
    DateTime CreatedAtUtc,
    DateTime UpdatedAtUtc);