using Yadino.Api.Database;

namespace Yadino.Infrastructure.Persistence.Configurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable(TableName.Note, schema: SchemaNames.Workspace);

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Content)
            .HasMaxLength(4000);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);
    }
}