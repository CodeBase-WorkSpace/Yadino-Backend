using Yadino.Domain.Enums.Notes;

namespace Yadino.Domain.Entities.Notes;

public sealed class Note
{
    public const int TitleMaxLength = 200;
    public const int ContentMaxLength = 4000;

    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public bool IsPinned { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsArchived { get; private set; }
    public NoteColor Color { get; private set; } = NoteColor.Default;
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime UpdatedAtUtc { get; private set; }

    private Note()
    {
    }

    private Note(Guid id, string title, string content, NoteColor color)
    {
        Id = id;
        Title = title;
        Content = content;
        Color = color;
        CreatedAtUtc = DateTime.UtcNow;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public static Note Create(
        string title,
        string? content,
        NoteColor color = NoteColor.Default,
        Guid? id = null)
    {
        var noteId = id ?? Guid.CreateVersion7();
        if (noteId == Guid.Empty)
        {
            throw NoteErrors.EmptyId();
        }

        var validTitle = ValidateTitle(title);
        var validContent = ValidateContent(content);
        var validColor = ValidateColor(color);

        return new Note(noteId, validTitle, validContent, validColor);
    }

    public void Update(string title, string? content, NoteColor color)
    {
        EnsureNotDeleted();

        Title = ValidateTitle(title);
        Content = ValidateContent(content);
        Color = ValidateColor(color);
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void Patch(string? title = null, string? content = null, NoteColor? color = null)
    {
        EnsureNotDeleted();

        var hasChanges = false;

        if (title is not null)
        {
            Title = ValidateTitle(title);
            hasChanges = true;
        }

        if (content is not null)
        {
            Content = ValidateContent(content);
            hasChanges = true;
        }

        if (color.HasValue)
        {
            Color = ValidateColor(color.Value);
            hasChanges = true;
        }

        if (hasChanges)
        {
            UpdatedAtUtc = DateTime.UtcNow;
        }
    }

    public void TogglePin()
    {
        EnsureNotDeleted();

        if (!IsPinned && IsArchived)
        {
            throw NoteErrors.CannotPinArchived();
        }

        IsPinned = !IsPinned;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void ToggleArchived()
    {
        EnsureNotDeleted();

        IsArchived = !IsArchived;

        if (IsArchived)
        {
            IsPinned = false;
        }

        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void SoftDelete()
    {
        if (IsDeleted)
        {
            throw NoteErrors.AlreadyDeleted();
        }

        IsDeleted = true;
        IsPinned = false;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void Restore()
    {
        if (!IsDeleted)
        {
            throw NoteErrors.NotDeleted();
        }

        IsDeleted = false;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    private void EnsureNotDeleted()
    {
        if (IsDeleted)
        {
            throw NoteErrors.CannotModifyDeleted();
        }
    }

    private static string ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw NoteErrors.TitleRequired();
        }

        var trimmed = title.Trim();
        if (trimmed.Length > TitleMaxLength)
        {
            throw NoteErrors.TitleTooLong(TitleMaxLength);
        }

        return trimmed;
    }

    private static string ValidateContent(string? content)
    {
        var normalized = content ?? string.Empty;

        if (normalized.Length > ContentMaxLength)
        {
            throw NoteErrors.ContentTooLong(ContentMaxLength);
        }

        return normalized;
    }

    private static NoteColor ValidateColor(NoteColor color)
    {
        if (!Enum.IsDefined(color))
        {
            throw NoteErrors.InvalidColor(color);
        }

        return color;
    }
}