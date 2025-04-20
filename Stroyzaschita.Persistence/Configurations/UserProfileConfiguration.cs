using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;

namespace Stroyzaschita.Persistence.Configurations;

class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile> {
    private const int _MAX_FIELD_LENGTH = 255;

    public void Configure(EntityTypeBuilder<UserProfile> builder) {
        builder.ToTable("users_data");

        builder.HasKey(userProfile => userProfile.UserId);

        builder.Property(userProfile => userProfile.UserId)
            .HasColumnName("user_id");

        builder.Property(userProfile => userProfile.Name)
            .HasColumnName("name")
            .HasMaxLength(_MAX_FIELD_LENGTH);

        //
        // TODO: CategoryId, ObjectName, Avatar, ContractExpiredAt. Спать хочу

        builder.Property(userProfile => userProfile.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(50);

        builder.Property(userProfile => userProfile.Address)
            .HasColumnName("address")
            .HasMaxLength(_MAX_FIELD_LENGTH);

    }
}
