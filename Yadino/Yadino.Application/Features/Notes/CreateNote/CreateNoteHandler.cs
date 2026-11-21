using Yadino.Domain.Entities.Notes;

namespace Yadino.Application.Features.Notes.CreateNote;

using FluentValidation;
using Yadino.Application.Common.Abstractions;
using Yadino.Application.Common.Exceptions;
using Yadino.Application.Common.Interfaces;


public sealed class CreateNoteHandler(
    IYadinoDbContext dbContext,
    IValidator<CreateNoteCommand> validator)
    : ICommandHandler<CreateNoteCommand, CreateNoteResult>
{
    public async Task<CreateNoteResult> HandleAsync(
        CreateNoteCommand command,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ApplicationValidationException(validationResult.Errors);
        }

        var note = Note.Create(command.Title, command.Content);

        dbContext.Notes.Add(note);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateNoteResult(
            note.Id,
            note.Title,
            note.Content,
            note.CreatedAtUtc,
            note.UpdatedAtUtc);
    }
}