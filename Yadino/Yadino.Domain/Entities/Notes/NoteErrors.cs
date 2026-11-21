using Yadino.Domain.Enums.Notes;

namespace Yadino.Domain.Entities.Notes;
using Yadino.Domain.Common.Exceptions;

public static class NoteErrors
{
    public static DomainException EmptyId() =>
        new("Note.EmptyId", "Note ID cannot be empty.");

    public static DomainException TitleRequired() =>
        new("Note.TitleRequired", "Note title cannot be empty.");

    public static DomainException TitleTooLong(int maxLength) =>
        new("Note.TitleTooLong", $"Note title cannot exceed {maxLength} characters.");

    public static DomainException ContentTooLong(int maxLength) =>
        new("Note.ContentTooLong", $"Note content cannot exceed {maxLength} characters.");

    public static DomainException InvalidColor(NoteColor color) =>
        new("Note.InvalidColor", $"'{color}' is not a valid note color.");

    public static DomainException AlreadyDeleted() =>
        new("Note.AlreadyDeleted", "This note has already been deleted.");

    public static DomainException NotDeleted() =>
        new("Note.NotDeleted", "Cannot restore a note that is not deleted.");

    public static DomainException CannotModifyDeleted() =>
        new("Note.CannotModifyDeleted", "Cannot modify a deleted note. Restore it first.");

    public static DomainException CannotPinArchived() =>
        new("Note.CannotPinArchived", "Cannot pin an archived note. Unarchive it first.");
}