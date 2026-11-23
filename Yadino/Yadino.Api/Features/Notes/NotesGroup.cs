namespace Yadino.Api.Features.Notes;

using FastEndpoints;


public sealed class NotesGroup : Group
{
    public NotesGroup()
    {
        Configure("notes", ep =>
        {
            ep.Description(x => x
                .WithTags("Notes")
                .ProducesProblemDetails(StatusCodes.Status400BadRequest)
                .ProducesProblemDetails(StatusCodes.Status500InternalServerError));
        });
    }
}