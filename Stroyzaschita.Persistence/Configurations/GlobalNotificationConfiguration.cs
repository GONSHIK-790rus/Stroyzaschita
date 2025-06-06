using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class GlobalNotificationConfiguration : IEntityTypeConfiguration<GlobalNotification> {
    public void Configure(EntityTypeBuilder<GlobalNotification> builder) {
        builder.ToTable("global_notifications");

        builder.HasKey(globalNotification => globalNotification.Id);

        builder.Property(globalNotification => globalNotification.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(globalNotification => globalNotification.Type)
            .HasColumnName("type")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH);

        builder.Property(globalNotification => globalNotification.Title)
            .HasColumnName("title")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH);

        builder.Property(globalNotification => globalNotification.Description)
            .HasColumnName("description")
            .HasMaxLength(FieldLengths.LONG_FIELD_LENGTH);

        builder.Property(globalNotification => globalNotification.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
    }
}
