namespace Yadino.Domain.Notes;

public sealed class Note
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    
    
    private Note(){}
    
    public Note(Guid id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
    }
    
}