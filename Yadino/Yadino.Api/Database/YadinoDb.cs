using Microsoft.EntityFrameworkCore;
using Yadino.Api.Database.note;

namespace Yadino.Api.Database;

public class YadinoDb(DbContextOptions<YadinoDb> options) : DbContext(options)
{
    DbSet<NoteEntity> Note => Set<NoteEntity>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(YadinoDb).Assembly);
    }
}