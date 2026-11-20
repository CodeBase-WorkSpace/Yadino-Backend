using Yadino.Domain.Enums.Notes;

namespace Yadino.Domain.Notes;

public sealed class Note
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public bool IsPinned { get; private set; } = false;
    public bool IsDeleted { get; private set; } = false;
    public bool IsArchived { get; private set; } = false;
    public NoteColor Color { get; private set; } = NoteColor.Default;
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime UpdatedAtUtc { get; private set; }

    private Note()
    {
    }

    public Note(Guid id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
        CreatedAtUtc = DateTime.UtcNow;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void Update(string title, string content, NoteColor color)
    {
        Title = title;
        Content = content;
        UpdatedAtUtc = DateTime.UtcNow;
        Color = color;
    }

    public void TogglePin()
    {
        IsPinned = !IsPinned;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void SoftDelete()
    {
        IsDeleted = true;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void ToggleArchived()
    {
        IsArchived = !IsArchived;
        UpdatedAtUtc = DateTime.UtcNow;
    }
    
    public void Patch(string? title, string? content)
    {
        if (title is not null)
        {
            Title = title;
        }

        if (content is not null)
        {
            Content = content;
        }

        UpdatedAtUtc = DateTime.UtcNow;
    }
}