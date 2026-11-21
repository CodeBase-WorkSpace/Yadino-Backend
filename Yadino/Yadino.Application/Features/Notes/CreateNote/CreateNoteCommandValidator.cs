using Yadino.Domain.Entities.Notes;

namespace Yadino.Application.Features.Notes.CreateNote;

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Yadino.Application.Common.Interfaces;

public sealed class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    private readonly IYadinoDbContext _dbContext;

    public CreateNoteCommandValidator(IYadinoDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(Domain.Entities.Notes.Note.TitleMaxLength)
            .MustAsync(BeUniqueTitleAsync)
            .WithMessage("A note with this title already exists.");

        RuleFor(x => x.Content)
            .MaximumLength(Domain.Entities.Notes.Note.ContentMaxLength);
    }

    private async Task<bool> BeUniqueTitleAsync(string title, CancellationToken ct)
    {
        var normalized = title.Trim();
        return !await _dbContext.Notes
            .AnyAsync(n => n.Title == normalized, ct);
    }
}