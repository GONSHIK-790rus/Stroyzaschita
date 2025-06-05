using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Shared.Constants;

namespace Stroyzaschita.Persistence.Configurations;

public class UserAddressesConfiguration : IEntityTypeConfiguration<UserAddresses> {
    public void Configure(EntityTypeBuilder<UserAddresses> builder) {
        builder.ToTable("user_addresses");

        builder.HasKey(address => address.Id);

        builder.Property(address => address.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(address => address.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(address => address.Address)
            .HasColumnName("address")
            .HasMaxLength(FieldLengths.LONG_FIELD_LENGTH)
            .IsRequired();

        builder.HasOne(address => address.User)
            .WithMany(user => user.Addresses)
            .HasForeignKey(address => address.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
