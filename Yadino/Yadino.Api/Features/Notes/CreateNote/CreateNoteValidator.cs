using FastEndpoints;
using FluentValidation;
using Yadino.Domain.Entities.Notes;

namespace Yadino.Api.Features.Notes.CreateNote;

public sealed class CreateNoteValidator : Validator<CreateNoteRequest>
{
    public CreateNoteValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(Note.TitleMaxLength)
            .WithMessage($"Title must not exceed {Note.TitleMaxLength} characters.");

        RuleFor(x => x.Content)
            .MaximumLength(Note.ContentMaxLength)
            .WithMessage($"Content must not exceed {Note.ContentMaxLength} characters.");
    }
}