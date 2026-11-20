using Microsoft.EntityFrameworkCore;
using Yadino.Domain.Notes;

namespace Yadino.Application.Common.Interfaces;

public interface IYadinoDbContext
{
    DbSet<Note> Notes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}