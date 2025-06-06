using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile> {
    public void Configure(EntityTypeBuilder<UserProfile> builder) {
        builder.ToTable("users_data");

        builder.HasKey(userProfile => userProfile.UserId);

        builder.Property(userProfile => userProfile.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(userProfile => userProfile.CategoryId)
            .HasColumnName("category_id");

        builder.Property(userProfile => userProfile.Name)
            .HasColumnName("name")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH);

        builder.Property(userProfile => userProfile.ObjectName)
            .HasColumnName("object_name")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH);

        builder.Property(userProfile => userProfile.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(FieldLengths.PHONE_FIELD_LENGTH)
            .IsRequired();

        builder.Property(userProfile => userProfile.Address)
            .HasColumnName("address")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH);

        builder.Property(userProfile => userProfile.Avatar)
            .HasColumnName("avatar")
            .HasColumnType("bytea"); // <- PostgreSQL specific type for byte array

        builder.Property(userProfile => userProfile.ContractExpiredAt)
            .HasColumnName("contract_expired_at")
            .IsRequired();

        builder.HasOne(userProfile => userProfile.User)
            .WithOne(user => user.UserProfile)
            .HasForeignKey<UserProfile>(userProfile => userProfile.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
