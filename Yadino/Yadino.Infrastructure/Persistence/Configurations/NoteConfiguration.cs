using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yadino.Domain.Notes;
using Yadino.Infrastructure.Persistence.Constants;

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
        
        builder.Property(n => n.CreatedAtUtc)
            .IsRequired();

        builder.Property(n => n.UpdatedAtUtc)
            .IsRequired();
    }
}