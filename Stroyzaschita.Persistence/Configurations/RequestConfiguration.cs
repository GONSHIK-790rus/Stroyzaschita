using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request> {
    public void Configure(EntityTypeBuilder<Request> builder) {
        builder.ToTable("requests");

        builder.HasKey(request => request.Id);

        builder.Property(request => request.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(request => request.Title)
            .HasColumnName("title")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();

        builder.Property(request => request.Description)
            .HasColumnName("description")
            .HasMaxLength(FieldLengths.LONG_FIELD_LENGTH);

        builder.Property(request => request.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(request => request.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(request => request.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.HasOne(request => request.User)
            .WithMany(user => user.Requests)
            .HasForeignKey(request => request.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}