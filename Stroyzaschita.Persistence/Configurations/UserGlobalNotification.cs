using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stroyzaschita.Domain.Entities;

namespace Stroyzaschita.Persistence.Configurations;

public class UserGlobalNotificationConfiguration : IEntityTypeConfiguration<UserGlobalNotification> {
    public void Configure(EntityTypeBuilder<UserGlobalNotification> builder) {
        builder.ToTable("user_global_notifications");

        builder.HasKey(userGlobalNotification => new { 
            userGlobalNotification.UserId, 
            userGlobalNotification.NotificationId 
        });

        builder.Property(userGlobalNotification => userGlobalNotification.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(userGlobalNotification => userGlobalNotification.NotificationId)
            .HasColumnName("notification_id")
            .IsRequired();

        builder.Property(userGlobalNotification => userGlobalNotification.ReadAt)
            .HasColumnName("read_at");

        builder.HasOne(userGlobalNotification => userGlobalNotification.User)
            .WithMany()
            .HasForeignKey(userGlobalNotification => userGlobalNotification.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(userGlobalNotification => userGlobalNotification.Notification)
            .WithMany()
            .HasForeignKey(userGlobalNotification => userGlobalNotification.NotificationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
