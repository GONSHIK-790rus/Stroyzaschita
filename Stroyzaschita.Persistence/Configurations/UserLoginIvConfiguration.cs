using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class UserLoginIvConfiguration : IEntityTypeConfiguration<UserLoginIv> {
    public void Configure(EntityTypeBuilder<UserLoginIv> builder) {
        builder.ToTable("user_login_ivs");

        builder.HasKey(userLoginIv => userLoginIv.UserId);

        builder.Property(userloginIv => userloginIv.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(userLoginIv => userLoginIv.Iv)
            .HasColumnName("iv")
            .HasMaxLength(FieldLengths.DEFAULT_FIELD_LENGTH)
            .IsRequired();

        builder.HasOne(userLoginIv => userLoginIv.User)
            .WithOne(user => user.LoginIv)
            .HasForeignKey<UserLoginIv>(iv => iv.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
