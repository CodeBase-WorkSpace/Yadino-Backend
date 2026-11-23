namespace Yadino.Api.Features.Notes.CreateNote;

using FastEndpoints;
using Yadino.Application.Features.Notes.CreateNote;

public sealed class CreateNoteEndpoint(Application.Common.Abstractions.ICommandHandler<CreateNoteCommand, CreateNoteResult> handler)
    : Endpoint<CreateNoteRequest, CreateNoteResponse>
{
    public override void Configure()
    {
        Post("");
        Group<NotesGroup>();
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Create a new note";
            s.Description = "Creates a new note in the workspace and returns its details.";
        });
    }

    public override async Task HandleAsync(CreateNoteRequest req, CancellationToken ct)
    {
        var command = new CreateNoteCommand(req.Title, req.Content);
        var result = await handler.HandleAsync(command, ct);

        var response = new CreateNoteResponse(
            result.Id,
            result.Title,
            result.Content,
            result.CreatedAtUtc,
            result.UpdatedAtUtc);

        await Send.ResponseAsync(response, StatusCodes.Status201Created, ct);
    }
}