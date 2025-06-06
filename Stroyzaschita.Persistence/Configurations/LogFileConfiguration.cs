using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class LogFileConfiguration : IEntityTypeConfiguration<LogFile> {
    public void Configure(EntityTypeBuilder<LogFile> builder) {
        builder.ToTable("log_files");

        builder.HasKey(logFile => logFile.Id);

        builder.Property(logFile => logFile.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(logFile => logFile.FileName)
            .HasColumnName("file_name")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();

        builder.Property(logFile => logFile.FileData)
            .HasColumnName("file_data")
            .HasColumnType("bytea") // <- PostgreSQL specific type for byte array
            .IsRequired();

        builder.Property(logFile => logFile.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
    }
}
