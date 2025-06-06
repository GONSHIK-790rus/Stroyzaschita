using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class DocumentCategoryConfiguration : IEntityTypeConfiguration<DocumentCategory> {
    public void Configure(EntityTypeBuilder<DocumentCategory> builder) {
        builder.ToTable("document_categories");

        builder.HasKey(documentCategory => documentCategory.Id);

        builder.Property(documentCategory => documentCategory.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(documentCategory => documentCategory.Name)
            .HasColumnName("name")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();
    }
}
