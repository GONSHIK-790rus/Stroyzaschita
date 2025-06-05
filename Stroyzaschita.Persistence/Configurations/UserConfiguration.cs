using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.ToTable("users");
        
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasColumnName("id")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();

        builder.Property(user => user.Login)
            .HasColumnName("login")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();

        builder.Property(user => user.PasswordHash)
            .HasColumnName("password")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();

        builder.Property(user => user.PasswordSalt)
            .HasColumnName("password_salt")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();

        builder.HasOne(user => user.Role)
            .WithMany()
            .HasForeignKey(user => user.RoleId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(user => user.UserProfile)
            .WithOne(userProfile => userProfile.User)
            .HasForeignKey<UserProfile>(userProfile => userProfile.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(user => user.Addresses)
               .WithOne(userAddress => userAddress.User)
               .HasForeignKey(userAddress => userAddress.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
