using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole> {
    public void Configure(EntityTypeBuilder<UserRole> builder) {
        builder.ToTable("roles");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(r => r.Name)
            .HasColumnName("name")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();
    }
}
