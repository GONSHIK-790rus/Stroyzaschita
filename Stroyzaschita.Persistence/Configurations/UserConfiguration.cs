using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;

namespace Stroyzaschita.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User> {
    private const int _MAX_FIELD_LENGTH = 255;

    public void Configure(EntityTypeBuilder<User> builder) {
        builder.ToTable("users");
        
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasColumnName("id")
            .HasMaxLength(_MAX_FIELD_LENGTH)
            .IsRequired();

        builder.Property(user => user.Login)
            .HasColumnName("login")
            .HasMaxLength(_MAX_FIELD_LENGTH)
            .IsRequired();

        builder.Property(user => user.PasswordHash)
            .HasColumnName("password")
            .HasMaxLength(_MAX_FIELD_LENGTH)
            .IsRequired();

        builder.HasOne(user => user.UserProfile)
            .WithOne(userProfile => userProfile.User)
            .HasForeignKey<UserProfile>(userProfile => userProfile.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
