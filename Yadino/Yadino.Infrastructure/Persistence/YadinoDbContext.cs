using Microsoft.EntityFrameworkCore;
using Yadino.Application.Common.Interfaces;
using Yadino.Domain.Entities.Notes;

namespace Yadino.Infrastructure.Persistence;

public sealed class YadinoDbContext : DbContext, IYadinoDbContext
{
    public YadinoDbContext(DbContextOptions<YadinoDbContext> options)
        : base(options)
    {
    }

    public DbSet<Note> Notes => Set<Note>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(YadinoDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}