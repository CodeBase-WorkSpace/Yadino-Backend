using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yadino.Domain.Entities.Notes;
using Yadino.Infrastructure.Persistence.Constants;

namespace Yadino.Infrastructure.Persistence.Configurations;

public sealed class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable(TableNames.Notes, SchemaNames.Workspace);

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Title)
            .IsRequired()
            .HasMaxLength(Note.TitleMaxLength);

        builder.Property(n => n.Content)
            .IsRequired()
            .HasMaxLength(Note.ContentMaxLength);

        builder.Property(n => n.IsPinned)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(n => n.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(n => n.IsArchived)
            .IsRequired()
            .HasDefaultValue(false);


        builder.Property(n => n.Color)
            .HasConversion<string>()
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(n => n.CreatedAtUtc)
            .IsRequired();

        builder.Property(n => n.UpdatedAtUtc)
            .IsRequired();
        
        builder.HasQueryFilter(n => !n.IsDeleted);
    }
}