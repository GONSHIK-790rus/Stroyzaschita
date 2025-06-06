using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;

namespace Stroyzaschita.Persistence.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document> {
    public void Configure(EntityTypeBuilder<Document> builder) {
        builder.ToTable("documents");

        builder.HasKey(document => document.Id);

        builder.Property(document => document.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(document => document.File)
            .HasColumnName("document")
            .HasColumnType("bytea")
            .IsRequired();

        builder.Property(document => document.DocumentCategoryId)
            .HasColumnName("document_category_id");

        builder.Property(document => document.AddedAt)
            .HasColumnName("added_at")
            .IsRequired();

        builder.HasOne(document => document.DocumentCategory)
            .WithMany()
            .HasForeignKey(document => document.DocumentCategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
