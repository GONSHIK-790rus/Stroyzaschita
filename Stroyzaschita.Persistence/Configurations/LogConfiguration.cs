using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class LogConfiguration : IEntityTypeConfiguration<Log> {
    public void Configure(EntityTypeBuilder<Log> builder) {
        builder.ToTable("logs");

        builder.HasKey(log => log.Id);

        builder.Property(log => log.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(log => log.UserId)
            .HasColumnName("user_id");

        builder.Property(log => log.Action)
            .HasColumnName("action")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();

        builder.Property(log => log.Description)
            .HasColumnName("description")
            .HasMaxLength(FieldLengths.LONG_FIELD_LENGTH);

        builder.Property(log => log.IpAddress)
            .HasColumnName("ip_address")
            .HasMaxLength(FieldLengths.IP_FIELD_LENGTH);

        builder.Property(log => log.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(log => log.User)
            .WithMany()
            .HasForeignKey(log => log.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
