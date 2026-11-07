using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Yadino.Api.Database.note;

public class NoteConfiguration : IEntityTypeConfiguration<NoteEntity>
{
    public void Configure(EntityTypeBuilder<NoteEntity> builder)
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