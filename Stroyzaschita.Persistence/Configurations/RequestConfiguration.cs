using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request> {
    public void Configure(EntityTypeBuilder<Request> builder) {
        builder.HasKey(request => request.Id);

        builder.Property(request => request.Title)
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();

        builder.Property(request => request.Description)
            .HasMaxLength(FieldLengths.LONG_FIELD_LENGTH);

        builder.Property(request => request.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(request => request.CreatedAt)
            .IsRequired();

        builder.HasOne(request => request.User)
            .WithMany(user => user.Requests)
            .HasForeignKey(request => request.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}