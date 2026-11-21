using Microsoft.EntityFrameworkCore;
using Yadino.Domain.Entities.Notes;

namespace Yadino.Application.Common.Interfaces;

public interface IYadinoDbContext
{
    DbSet<Note> Notes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}