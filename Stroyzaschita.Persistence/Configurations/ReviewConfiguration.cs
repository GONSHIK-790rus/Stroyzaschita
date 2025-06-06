using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review> {
    public void Configure(EntityTypeBuilder<Review> builder) {
        builder.ToTable("reviews");

        builder.HasKey(review => review.Id);

        builder.Property(review => review.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(review => review.AuthorId)
            .HasColumnName("author")
            .IsRequired();

        builder.Property(review => review.Text)
            .HasColumnName("text")
            .HasMaxLength(FieldLengths.LONG_FIELD_LENGTH)
            .IsRequired();

        builder.Property(review => review.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(review => review.Author)
            .WithMany()
            .HasForeignKey(review => review.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
