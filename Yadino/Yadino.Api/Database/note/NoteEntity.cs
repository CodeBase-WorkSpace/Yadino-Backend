namespace Yadino.Api.Database.note;

public sealed class NoteEntity
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    
    
    private NoteEntity(){}
    
    public NoteEntity(Guid id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
    }
    
}